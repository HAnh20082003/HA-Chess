Use QLCoVua;

Create table tb_Account
(
	ID int primary key identity,
	Name nvarchar(100) not null,
	UserName varchar(50) not null unique,
	Password varchar(50) not null,
	Status int not null default 0, --1: Online | 0: Offline | -1: In game | -2: Finding match
	IndexTypeGame int not null default 0,
	IndexNameRegime int not null default 0,
	ID_MatchAccount int references tb_Account(ID),
	ID_InviteAccount int references tb_Account(ID),
);
go

Create table tb_Elo
(
	ID int primary key identity(1,1),
	ID_Account int references tb_Account(ID),
	IndexTypeGame int,
	IndexNameRegime int,
	StrAccount text,
	Value int,
	Unique (ID_Account, IndexTypeGame, IndexNameRegime)
);
go

Create table tb_GroupMatch
(
	ID int primary key identity,
	ID_Account_1 int references tb_Account(ID) not null,
	ID_Account_2 int references tb_Account(ID) not null,
	StrAccount text default '' not null,
	IndexTypeGame int default 0 not null,
	IndexRegime int default 0 not null,
	Rematch_1 bit default 0 not null,
	Rematch_2 bit default 0 not null,
	Date date not null default GETDATE(),
);
go

Create table tb_Match
(
	STT int not null default 1,
	ID_GroupMatch int references tb_GroupMatch(ID) not null,
	Account_1_White bit not null default 1,
	Elo_White int not null, 
	Elo_Black int  not null,
	BonusEloWin int  not null default 0,
	BonusEloDraw int  not null default 0,
	Fen text not null,
	Move text not null default '',
	TimeEveryMove text not null default '',
	Chat ntext not null default '',
	Result int  not null default -2, --1: win, 0: draw, -1: lose, -2: chưa biết
	DetailResult ntext not null default '',
	Notation ntext not null default '',
	RequestDraw_W bit not null default 0,
	RequestDraw_B bit not null default 0,
	Resign_W bit not null default 0,
	Resign_B bit not null default 0,
	W_Out bit default 0,
	B_Out bit default 0,
	DateMatch datetime default getdate(),
	CurrentTurn bit, --1: trắng, 0: đen
	Primary key (STT, ID_GroupMatch)
);
go

Create table tb_Friend
(
	ID int primary key identity,
	ID_Account_1 int references tb_Account(ID) not null,
	ID_Account_2 int references tb_Account(ID) not null,
	StrAccount text not null,
	ID_Account_Send int references tb_Account(ID) not null,
	Status_1 int default -1, --1: đã kết bạn, 0: chưa kết bạn, -1: chưa đề xuất kết bạn
	Status_2 int default -1, --1: đã kết bạn, 0: chưa kết bạn, -1: chưa đề xuất kết bạn
	Chat ntext default '' not null,
	Date date default GETDATE() not null,
	Unique (ID_Account_1, ID_Account_2)
);
go

Create table tb_MyRoom
(
	ID int primary key references tb_Account(ID),
	ID_Opponent int references tb_Account(ID),
	IndexTypeGame int not null default 0,
	IndexRegime int not null default 0,
	YouWhite bit not null default 1, --1: bạn cầm cờ trắng | 0: bạn cầm cờ đen
	Fen text not null default '',
	StartGame bit not null default 0, --1: đã bắt đầu | 0: chưa bắt đầu
	Move text not null default '',
	TimeEveryMove text not null default '',
	Chat ntext not null default '',
	RequestDraw_You bit default 0,
	RequestDraw_Opponent bit default 0,
	Resign_You bit default 0,
	Resign_Opponent bit default 0,
	Opponent_Out bit default 0,
	Opponent_Accepted bit default 0,
	RestartGame bit not null default 0,
);
go

