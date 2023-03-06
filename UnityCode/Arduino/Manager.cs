using System;
using System.Collections;
using System.Collections.Generic;
using ArduinoBluetoothAPI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.IO.Ports;
using TTT= Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;

public class Manager : MonoBehaviour {

	// Use this for initialization
	public BluetoothHelper bluetoothHelper;
	string deviceName;
	[SerializeField]
	Toggle Toggle_isDevicePaired;
	[SerializeField]
	Toggle Toggle_isConnected;
	[SerializeField]
	GameObject DebugHolder;
	[SerializeField]
	Button Btn_Connect;
	[SerializeField]
	Button Btn_Disconnect;
	public GameObject GameObject;
	private int time_Max=0;

	public GameObject image__;
	public GameObject fish__;

	public string oh="2";
	public int check_time = 0;

	public Text Txt_Door;
	SerialPort serial = new SerialPort();
	//public enum PortNumber
	//   {
	//	COM1, COM2, COM3, COM4,
	//	COM5, COM6, COM7, COM8,
	//	COM9, COM10, COM11, COM12,
	//	COM13, COM14, COM15, COM16
	//}

	//private SerialPort serial;

	//[SerializeField]
	//private PortNumber portNumber = PortNumber.COM3;
	//[SerializeField]
	//private string baudRate = "9600";

	//public bool LEDLight = false;

	string received_message;
	// 외부에서 접근하여 사용할 수 있습니다.
	// 외부 다른 클래스에서 Manager 함수로 접근하여 Start 펑션에서 다음과 같이 사용하시면 됩니다.
	//===============================================
	// Manager.onDoorOpen.AddListener(OnDoorOpen);
	// Manager.onDoorClose.AddListener(OnDoorClose);
	//===============================================

	public UnityEvent onDoorOpen, onDoorClose;
	private bool check = true;
	public void connectblu()
    {
		deviceName = "HC-06"; //bluetooth should be turned ON; // 페어링되는 아두이노 블루투스 이름과 같아야 합니다.

		//=============================================================================================
		//=============================================================================================
		try
		{
			bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
			bluetoothHelper.OnConnected += OnConnected;
			bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
			bluetoothHelper.OnDataReceived += OnMessageReceived; //read the data

			bluetoothHelper.setTerminatorBasedStream("\n");




			if (bluetoothHelper.isDevicePaired())
				Toggle_isDevicePaired.isOn = true;
			else
				Toggle_isDevicePaired.isOn = false;
		}
		catch (Exception ex)
		{
			Toggle_isDevicePaired.isOn = false;
			Debug.Log(ex.Message);
		}
		if (bluetoothHelper.isDevicePaired())
		{
			Debug.Log("try to connect");
			bluetoothHelper.Connect(); // tries to connect
		}
		else
		{
			Debug.Log("not DevicePaired");
		}
	}

	public void clickLight()
	{
		Debug.Log("check : " + check);
		if (check)
		{
			//bluetoothHelper.Write
			//bluetoothHelper.SendData("0");
			//oh=bluetoothHelper.Read();
			//Debug.Log(oh);
			//bluetoothHelper.SendData("11111111  ");
			check = false;
		}
        else { 
			//bluetoothHelper.SendData("1");
			//oh = bluetoothHelper.Read();
			//Debug.Log(oh);
			check = true;
		}
	}

	void Start ()
	{
		serial.Close();

		serial = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);
		if (!serial.IsOpen)
        {
			Debug.Log("open");
			serial.Open();


		}
		//serial.ReadTimeout = 5;

/*		Btn_Connect.onClick.AddListener (() => {
			if (bluetoothHelper.isDevicePaired ()) {
				Debug.Log ("try to connect");
				bluetoothHelper.Connect (); // tries to connect
			} else {
				Debug.Log ("not DevicePaired");
			}
		});
		Btn_Disconnect.onClick.AddListener (() => {
			bluetoothHelper.Disconnect ();
			Debug.Log ("try to Disconnect");
		});*/
		//=============================================================================================
		//=============================================================================================

		
	}
	IEnumerator visualII()
    {
		yield return new WaitForSeconds(1);
		image__.SetActive(true);
		yield return new WaitForSeconds(1);
		image__.SetActive(false);
		yield return new WaitForSeconds(1);
		image__.SetActive(true);
		yield return new WaitForSeconds(1);
		image__.SetActive(false);
		yield return new WaitForSeconds(1);
		image__.SetActive(true);
		yield return new WaitForSeconds(1);
		image__.SetActive(false);
		yield return new WaitForSeconds(1);
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Alpha0)) {
			if (!isDebugOn) {
				isDebugOn = true;
				DebugHolder.SetActive (true);
			} else {
				isDebugOn = false;
				DebugHolder.SetActive (false);
				myLog = "reset";
			}
		}

		// LED 점등
		//if(GameObject.GetComponent<TTT.SolverHandler>().TransformTarget == null)
        //{
			//Debug.Log("ㅇㅇㅇ");
			//bluetoothHelper.SendData("1");
		//}

        /// 낚시 시뮬레이션
        /// 
		
		SolverHandler sloverhandler;
		sloverhandler = FindObjectOfType<SolverHandler>();
		//Debug.Log(sloverhandler.LEDBool);
		bool check_ad = GameObject.Find("manager2").GetComponent<fishing_animator>().check_ad;
        if (serial.IsOpen)
        {
            Debug.Log("oh::"+oh);
			serial.WriteLine(oh);
			serial.ReadTimeout = 30;
			//Debug.Log(serial.ReadLine());
			if (sloverhandler.LEDBool)
			//if (check_ad)
			{
				//Debug.Log(check_time);
				oh = "0";
				check_time++;
                // 
                if (check_time == 150) //random Number
                {
					StartCoroutine(visualII());
                }
				time_Max = check_time;
            }
            else
            {
				if (check_time <= 0)
				{
					oh = "2";
					//fish__.SetActive(false);
				}
				else
				{
					oh = "1";
					check_time--;
					//check_time--;
					if (check_time <= 50 && check_time > 0)
					{
						fish__.SetActive(true);
					}
				}
				Debug.Log(check_time);
				image__.SetActive(false);
				//fish__.SetActive(false);
			}
		}

    }

	//Asynchronous method to receive messages
	void OnMessageReceived () {
		received_message = bluetoothHelper.Read ();
		Debug.Log(received_message);

		if (received_message.Contains ("on")) {
			Txt_Door.text = "Door is close";
			onDoorClose.Invoke();
		}

		if (received_message.Contains ("off")) {
			Txt_Door.text = "Door is open";
			onDoorOpen.Invoke();
		}
	}

	void OnConnected () {
		Toggle_isConnected.isOn = true;
		try {
			bluetoothHelper.StartListening ();
			Debug.Log ("Connected");
			//bluetoothHelper.SendData("1");
		} catch (Exception ex) {
			Debug.Log (ex.Message);
		}
	}

	void OnConnectionFailed () {
		Toggle_isConnected.isOn = false;
		Debug.Log ("Connection Failed");
	}

	//Call this function to emulate message receiving from bluetooth while debugging on your PC.
	void OnGUI () {
		if (isDebugOn) {
			if (bluetoothHelper != null)
				bluetoothHelper.DrawGUI ();
			else
				return;

			if (!bluetoothHelper.isConnected ()) {
				Btn_Connect.interactable = true;
				Btn_Disconnect.interactable = false;
				Toggle_isConnected.isOn = false;
			}

			if (bluetoothHelper.isConnected ()) {
				Btn_Connect.interactable = false;
				Btn_Disconnect.interactable = true;
				Toggle_isConnected.isOn = true;
			}

			// Screen Debug
			GUIStyle myStyle = new GUIStyle ();
			myStyle.fontSize = 16;
			myStyle.normal.textColor = Color.blue;
			GUI.Label (new Rect (10, 100, 1080, 1920), myLog, myStyle);
		}
	}

	void OnDestroy () {
		if (bluetoothHelper != null)
			bluetoothHelper.Disconnect ();
	}

	void OnApplicationQuit () {
		if (bluetoothHelper != null)
			bluetoothHelper.Disconnect ();
	}

	// Screen Debug
	bool isDebugOn = true;
	string myLog;
	Queue myLogQueue = new Queue ();
	void OnEnable () {
		Application.logMessageReceived += HandleLog;
	}
	void OnDisable () {
		Application.logMessageReceived -= HandleLog;
	}
	void HandleLog (string logString, string stackTrace, LogType type) {
		myLog = logString;
		string newString = "[" + type + "] : " + myLog + "\n";
		myLogQueue.Enqueue (newString);
		if (type == LogType.Exception) {
			newString = "\n" + stackTrace;
			myLogQueue.Enqueue (newString);
		}
		myLog = string.Empty;
		foreach (string mylog in myLogQueue) {
			myLog += mylog;
		}
	}

	public void onCatch()
    {
		//TTT.TapToPlace.Led
		//GameObject.FindWithTag("man").GetComponent<>().onCatch();
		bluetoothHelper.SendData("1");
	}

	public void offCatch()
	{
		bluetoothHelper.SendData("0");
	}

}