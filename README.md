## Software

----------------

24년도 1학기에 만든 GameManager입니다.

재사용성과 확장성에 집중하였으며, C#으로 작성하였습니다.

Visual Studio 2022로 작업하였습니다.

----------------

대부분의 게임은 유저와 몬스터가 싸우고, 아이템을 드롭하는 과정이 포함되어 있으며 이를 다른 게임을 제작할 때에도 재사용 할 수 있다고 판단하여 주제를 잡게 되었습니다.

유저, 몬스터, 아이템의 생산은 Factory패턴을 사용하였고, 이 세 요소간의 상호작용은 GameManager이며 Mediator패턴으로 작성하였습니다.

유저는 기본적으로 방향키를 통해 한 칸을 움직일 수 있고, 엔터 키를 통해 아이템칸으로 들어갈 수 있습니다.

맵을 이동하면서 아이템을 찾고, 보물을 찾고, 몬스터와 전투하며 점수를 올리는 게임입니다.
