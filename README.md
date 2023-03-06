# HoloLens-VR-Interface

## 논문 : 가상환경에서 무게감을 효율적으로 사용자에게 전달하는 도르래방식의 VR 인터페이스
가상환경에서 무게감을 효율적으로 사용자에게 전달하는 도르래방식의 VR 인터페이스를 제안

<br>진행기간 2021/12/20 - 2022/12/28
<br><img src="https://img.shields.io/badge/Unity-FFFFFF?style=for-the-badge&logo=Unity&logoColor=black">
<img src="https://img.shields.io/badge/Arduino-00979D?style=for-the-badge&logo=Arduino&logoColor=white">

<br>
<aside>
📢 본 문서는 2023년 제 68차 한국컴퓨터 정보학회에 제출한 연구입니다. 저는 제 2저자입니다.

본 연구에서는 마이크로소프트의 홀로렌즈를 이용한 손 위치 추적 및 모션 인식과 아두이노를 사용하여 상황에 맞는 무게감을 사용자에게 전달할 수 있는 VR 인터페이스를 제안합니다.

</aside>
![Untitled](https://user-images.githubusercontent.com/76572665/223196560-1aa0f4bf-46ce-4c0f-8720-8104b25025f6.png)



- **문제:**
    - HoloLens를 사용하여 가상 물체와 상호작용할 때, 사용자는 현실과의 감각적인 상호작용이 부족하여 현실감이 떨어짐. 이는 몰입을 방해하는 요소입니다.
- **솔루션:**
    - 사용자는 도르래 인터페이스를 손등에 착용하고 HoloLens의 기능을 이용하여 손의 움직임이나 시야 정보를 통해 도르래 인터페이스를 작동시켜 무게감을 느낍니다.
- **기대효과:**
    - HMD 사용자나 비-HMD 사용자 모두에게 무게감을 전달할 수 있으며 해당 장치를 활용하여 사용자는 가상환경 내에서 더 높은 몰입감을 느끼며, 낚시, 재활 등 다양한 활동에서 더욱 즐길 수 있는 감각적인 상호작용을 경험할 수 있습니다.
    - HoloLens를 사용하여 가상의 물체를 잡는 등의 상호작용을 할 때, 현실과의 감각적인 상호 작용이 부족하여 현실감이 떨어지고, 이는 몰입을 방해하는 요소입니다.
    
    ## 🖥 사용 기술 및 라이브러리

- Unity, MRTK (Mixed Reality 도구키트)
- Arduino
- Hololens2 (Microsoft)

## 🖱 담당한 기능

- 모터 드라이버를 사용하여 상황에 따라 속도와 방향을 조절하여 무게감을 부여합니다.
    - 도르래를 사용하여 바닥과 물병의 높이 차이를 조절하여 무게감을 느끼게 합니다.
- 유니티와 아두이노 간의 통신을 통해 데이터를 전송합니다.
    - 아두이노에 데이터를 전송하여 모터의 속도와 방향 등을 조절합니다.
    - 상황에 맞춰 무게 조절이 가능하여 가상의 물체를 잡았을 때 현실감을 높이고 몰입감을 개선합니다.
- 테스트 환경을 구축했습니다.
    - 낚시 환경을 만들어서 자연스러움을 추가했습니다.

## 💡 깨달은 점

- 홀로렌즈의 **라이브러리**인 MRTK를 활용했습니다.
- 제공된 변수를 이용하기 위해 직접 코드를 해석했습니다. 이로 인해 **코드 해석 능력이 향상**되었습니다.

## 🎈기타

- [https://www.dbpia.co.kr/journal/articleDetail?nodeId=NODE11213510](https://www.dbpia.co.kr/journal/articleDetail?nodeId=NODE11213510)
- 해당 발표 영상은 [여기](https://www.youtube.com/watch?v=abS5pY5J6Hg)를 클릭하면 보실 수 있습니다.


    
