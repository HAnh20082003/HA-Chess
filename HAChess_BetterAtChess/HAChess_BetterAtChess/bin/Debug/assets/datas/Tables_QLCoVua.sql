Use QLCoVua;

Create table tb_Account
(
	ID int primary key identity,
	Name nvarchar(100),
	UserName varchar(50),
	Password varchar(50),
	Avatar varbinary(MAX),
	Status int, --1: Online | 0: Offline | -1: In game | -2: Private | -3: Finding match
	Date datetime,
);
go

Create table tb_Elo
(
	ID_Account int references tb_Account(ID),
	IndexTypeGame int,
	IndexNameRegime int,
	Value int,
);
go
Create table tb_FindMatch
(
	ID int primary key identity,
	ID_Account int references tb_Account(ID),
	IndexTypeGame int,
	IndexRegime int,
	Elo int,
	Found bit, --1: đã thấy | --0: chưa thấy
	ID_Account_Found int references tb_Account(ID),
	Status bit, --1: hoạt động, 0: ngừng hoạt động
);
go
Create table tb_Room
(
	ID int primary key identity,
	ID_FindMatch int references tb_FindMatch(ID),
	ID_Account int references tb_Account(ID), --Chủ room
	Name nvarchar(200),
	Password varchar(200),
	Status int, --1: Bth | 0: bảo trì | -1 trận đấu đang diễn ra
	IndexTypeGame int,
	IndexRegime int,
	Board ntext,
	Abilities ntext,
	StartWhiteTurn bit,
	StartCountMoveNoPawnNoCapture int,
	StartCountMoveOverall int,
);
go

Create table tb_Match
(
	ID int primary key identity,
	ID_Room int references tb_Room(ID),
	ID_Account_White int references tb_Account(ID),
	ID_Account_Black int references tb_Account(ID),
	Elo_White int, 
	Elo_Black int,
	Point_White float,
	Point_Black float,
	Result int,
	DetailResult ntext,
	Notation ntext,
	Date datetime,
	BonusEloWin int,
	Board ntext,
	Abilities ntext,
	StartWhiteTurn bit,
	StartCountMoveNoPawnNoCapture int,
	StartCountMoveOverall int,
);
go
Create table tb_PointMatch
(
	ID_Account_1 int references tb_Account(ID),
	ID_Account_2 int references tb_Account(ID),
	IndexTypeGame int,
	IndexRegime int,
	Point_1 float default 0,
	Point_2 float default 0,
	Primary key (ID_Account_1, ID_Account_2)
);
go

Create table tb_MoveInMatch
(
	ID_Match int references tb_Match(ID),
	ID_Account int references tb_Account(ID),
	IndexMove int,
	Move text,
	NameNotation text,
	Time text,
	Primary key (ID_Match, IndexMove),
);
go
Create table tb_MatchRoomPrivate
(
	ID int primary key identity,
	ID_Room int references tb_Room(ID),
	ID_Account_White int,
	ID_Account_Black int,
	Bot_white bit,
	Bot_black bit,
	Elo_White int, 
	Elo_Black int,
	Result int,
	DetailResult ntext,
	Notation ntext,
	Date datetime,
	Board ntext,
	Abilities ntext,
	StartWhiteTurn bit,
	StartCountMoveNoPawnNoCapture int,
	StartCountMoveOverall int,
);

Create table tb_MoveInMatchRoomPrivate
(
	ID_Match int references tb_MatchRoomPrivate(ID),
	ID_Account int,
	IndexMove int,
	Move text,
	NameNotation text,
	Time text,
	Primary key (ID_Match, IndexMove),
);
go

Create table tb_Notification
(
	ID int primary key identity,
	ID_Room int references tb_Room(ID),
	ID_Account int references tb_Account(ID),
	IndexNoti int,
	Seen ntext, --liệt kê id các account đã xem thông báo được gửi
	Response int, --1: Yes | 0: Unknow | -1: No
);
go
Create table tb_ChatRoom
(
	ID_Room int references tb_Room(ID),
	IndexChat INT,
	ID_Account int references tb_Account(ID),
	Content ntext,
	Date datetime,
	Primary key (ID_Room, IndexChat)
);
go
Create table tb_PlayerInRoom
(
	ID_Room int references tb_Room(ID),
	ID_Account int references tb_Account(ID),
	Primary key (ID_Room, ID_Account),
);
go
Create table tb_PlayerJoinRoom
(
	ID_Room int references tb_Room(ID),
	ID_Account int references tb_Account(ID),
);
go
Create table tb_PlayerOutRoom
(
	ID_Room int references tb_Room(ID),
	ID_Account int references tb_Account(ID),
);
go
Create table tb_Friend
(
	ID int primary key identity,
	ID_Account_1 int references tb_Account(ID),
	ID_Account_2 int references tb_Account(ID),
	Date datetime,
);
go
drop table tb_Friend
Create table tb_InviteAFriend
(
	ID_Account_Send int references tb_Account(ID),
	ID_Account_Receive int references tb_Account(ID),
	Date datetime,
	Primary key(ID_Account_Send, ID_Account_Receive)
);
go
Create table tb_PersonalMessage 
(
	ID_Friend int references tb_Friend(ID),
	ID_Account_Send int references tb_Account(ID),
	Indexx int,
	Content ntext,
	Date datetime,
	Seen bit, --1: seen | 0: unseen
	Primary key (ID_Friend, Indexx),
);
go
drop table tb_PersonalMessage

Create table tb_Player
(
	ID int primary key identity,
	Name nvarchar(200),
	Avatar ntext,
	TypePlayer bit, --1: Người, 0: bot
);
go

Create table tb_MatchPlayer
(
	ID int primary key identity,
	ID_Player int references tb_Player(ID),
	White bit,
	Title ntext,
	Fen text,
	Move text,
	Notation text,
	Result int, --1: win, 0: draw, -1: lose
	DetailResult ntext,
);
go