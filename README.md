# [Unity 2D] BakeryRPG

## 1. 프로젝트 소개
<p align="center">
  <img src = "https://github.com/SeoJeong1105/BakeryRPG/assets/66478240/87290cc3-8acb-4b30-af63-09fb969e5ee9" width = "20%">
  <img src = "https://github.com/SeoJeong1105/BakeryRPG/assets/66478240/ead55f18-59df-486c-9ca3-4ec17d0b70d1" width = "20%"> 
  <img src = "https://github.com/SeoJeong1105/BakeryRPG/assets/66478240/7959a857-766d-4533-ac8d-2f51ceca4dc3" width = "20%">
</p>
<p align="center">
  <img src = "https://github.com/SeoJeong1105/BakeryRPG/assets/66478240/ec4e1fae-33de-468a-acaf-828f6ae3849d" width = "20%"> 
  <img src = "https://github.com/SeoJeong1105/BakeryRPG/assets/66478240/dc1a9028-bfbf-496c-bee6-cf4f6fa58ade" width = "20%">
  <img src = "https://github.com/SeoJeong1105/BakeryRPG/assets/66478240/a60e0626-541b-463c-b754-16adba5d8852" width = "20%">
</p>

* Unity 2D 모바일 게임
* 베이커리를 운영하며 몬스터를 사낭
* 재료는 2개의 미니게임을 통해 얻거나 시장에서 구매
* 몬스터를 사냥하여 경험치를 획득하고, 경험치로 스탯을 구매

## 2. 개발 환경
* Unity
* C#

## 3. 사용 기술
|기술|설명|
|:---------:|:-----------:|
|Singleton|Manager, Inventory 관리|
|Obejct Pooling|과일, 몬스터의 오브젝트 재사용|
|Coroutine|과일, 손님의 생성 시간 조절|
|Scriptable Object|아이템, 메뉴를 Prefab화하여 메모리 절약|
  
## 4. 구현 기능
### (1) 베이커리 운영
* 제작
  * 오븐의 제작하기 버튼으로 메뉴 선택 창 팝업, 메뉴 클릭하면 제작 시작
* 손님
  * 랜덤으로 메뉴와 수량 요구
* 판매
  * 진열된 메뉴 클릭 시 판매

### (2) 몬스터 사냥
* 뱀파이어 서바이벌 류의 미니 게임
* 제한 시간이 끝나거나 캐릭터의 체력이 0이 되면 종료
* 맵
  * 타일맵의 위치 이동으로 무한 맵 생성
* 몬스터
  * 무한 생성되며 시간에 따라 레벨 증가
  * 캐릭터의 무기에 닿으면 체력 감소
* 캐릭터
  * 범위 내 몬스터가 있을 시 자동으로 무기 휘두름
    
### (3) 미니 게임
* 베이킹에 사용하는 재료 수급
  
#### 1) 과일 받기
* 하트가 0개가 되면 종료
* 과일
  * 랜덤으로 썩은 과일 생성
  * 캐릭터에 닿으면 점수 증가하거나 하트 감소

#### 2) 잡초 뽑기
* 두더지 잡기 류의 미니 게임
* 그리드에 랜덤으로 잡초 생성
* 잡초를 클릭하면 점수 증가
* 제한 시간 끝나면 종료

### (4) 상점
* 상점의 범위 내에서 상점 클릭하면 판매 리스트 창 팝업
* 아이템 슬롯 클릭하여 구매

### (5) 인벤토리
* 아이템 Scriptable object를 저장
  * Sprite, 이름, 가격 등 저장
* 미니 게임에서 얻거나 상점에서 아이템 구매 시 자동으로 추가
