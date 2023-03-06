#include <SoftwareSerial.h>
#define btx_r 10
#define btx_t 11
SoftwareSerial bluetooth(btx_r, btx_t);

// 3번과 4번 핀은 모터 제어에 관한 핀
int IN1Pin = 3;
int IN2Pin = 4;

// 5번핀은 모터의 힘을 설정해주는 핀
int ENPin = 5;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  bluetooth.begin(9600);
  pinMode(IN1Pin, OUTPUT);
  pinMode(IN2Pin, OUTPUT); // 3, 4번 제어핀들은 핀모드를 출력은로 설정
  analogWrite(ENPin, 255); //5번 핀에 255의 최대 힘을 설정한다. 
  
  pinMode(11, OUTPUT);  // 2. 8번 핀을 출력으로 설정합니다.
  digitalWrite(11, LOW);
}

void forward(){
  digitalWrite(IN1Pin, HIGH); 
  digitalWrite(IN2Pin, LOW);
}

void back(){
  digitalWrite(IN1Pin, LOW);
  digitalWrite(IN2Pin, HIGH); 
}

void loop() {
    if(Serial.available()){
      while(Serial.available()){
        char data = Serial.read();
        Serial.write(data);
        digitalWrite(11, HIGH);
        if(data == '0'){
          forward();
          Serial.write("forward");
        }else if(data == '1'){
          back();
          Serial.write("back");
        }else{
          digitalWrite(IN1Pin, HIGH);
          digitalWrite(IN2Pin, HIGH);
          Serial.write("stop");
        }
        Serial.println(data);
        }
    }
      if(bluetooth.available()){}
}
