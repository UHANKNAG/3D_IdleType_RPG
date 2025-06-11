# 🔥 Unity Idle RPG Project

이 프로젝트는 Unity를 기반으로 한 3D **Idle RPG 스타일 게임**입니다. 

플레이어는 자동으로 이동하며 적이나 오브젝트를 추가 처치하고, 아이템과 골드를 획득해 스탯을 강화하고 스테이지를 진행하게 됩니다.

![GamePlay](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/3DIdleRPGGamePlay.gif)

##


## 📌 구현된 기능

### 1. 💥 기본 UI 구현

* 플레이어의 **HP, MP, 경험치바** 표시
* **현재 스테이지** 및 **골드** 보유량 표시

![BasicUI](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/BasicUI.png)
  

### 2. 🤖 플레이어 AI 시스템

* \*\*FSM(Finite State Machine)\*\*과 **Coroutine**을 이용한 AI 동작 구현
* 플레이어는 **자동으로 전방 이동**
* 특정 조건 충족 시, 일정 주기로 **자동 공격(Attack)** 수행

![FSM](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/FSM.gif)  


### 3. 🧪 아이템 시스템

* 적 또는 오브젝트 처치 시 **아이템 드래프**
* 아이템 사용 시 **스템 강화**

  * 체력 회복
  * 이동 속도 증가
  * 공격력 증가

![Item](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/Item.png)


### 4. 💰 게임 내 통화 시스템

* 적이나 오브젝트 처치 시 **골드 획득**
* 획득한 골드는 UI에 실시간 반영

![Gold](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/Gold.png)
  

### 5. 🎒 인벤토리 시스템

* **버튼 클릭**으로 인벤토리 창 열기
* 인벤토리 내 **아이템 클릭 시 사용 가능**

![Inventory](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/Inventory.gif)


### 6. 📦 ScriptableObject 기반 데이터 관리

* **CollectObject**: 플레이어가 처치해야 할 오브젝트 정의
* **ItemObject**: 드래프될 아이템 정의
* ScriptableObject를 통해 각 객체의 속성 및 보상 데이터를 분리 관리

![ScriptableObject](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/ScriptableObject.png)


### 7. 🗺️ 스테이지 및 웨이브 시스템

* 맵의 진행도에 따라 **웨이브(wave)** 증가
* 웨이브 진행도에 따른 스테이지(stage) 상승
* 스테이지 변화는 UI에 실시간 반영

![Stage](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/Stage.png)


### 8. 🎲 Collect 랜덤 생성 시스템

* ScriptableObject를 포함한 CollectPrefab을 **CollectManager**를 통해 맵 위에 **랜덤 배치**

![CollectManager](https://github.com/UHANKNAG/3D_IdleType_RPG/blob/main/READMEfiles/CollectManager.png)
  

## 🛠️ 기술 스택

* Unity&#x20;
* C#
* FSM 구조 기반 자동화 시스템
* ScriptableObject를 활용한 데이터 분리


