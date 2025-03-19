Use QLCoVua;

Delete tb_Account;
Select * from tb_Account;
Update tb_Account Set Status = 0


Select * from tb_Elo
delete tb_Elo


DBCC CHECKIDENT ('tb_MatchRoomPrivate', RESEED, 0)


Select * from tb_FindMatch;
Insert into tb_FindMatch values (-1, 0, 0, -1, -1)

DBCC CHECKIDENT ('tb_Notification', RESEED, 0)
drop table tb_FindMatch


DBCC CHECKIDENT ('tb_Room', RESEED, 22)
drop table tb_Room


Select * from tb_Match
Delete tb_Match;
DBCC CHECKIDENT ('tb_Match', RESEED, 0)
drop table tb_Match


drop table tb_InfoMatch


select * from tb_PointMatch
drop table tb_PointMatch



select * from tb_PointMatchRoom
drop table tb_PointMatchRoom


drop table tb_MoveInMatch


Select * from tb_Notification;
DBCC CHECKIDENT ('tb_Notification', RESEED, 0)
Delete tb_Notification
drop table tb_Notification


Select * from tb_ChatRoom
Insert into tb_ChatRoom values (25, 1, 5, N'Nà ní', GETDATE())
Delete tb_ChatRoom
drop table tb_ChatRoom


Select * from tb_PlayerInRoom
drop table tb_PlayerInRoom


drop table tb_PlayerJoinRoom


drop table tb_SeenJoinRoom


drop table tb_PlayerOutRoom


drop table tb_SeenOutRoom


Select * from tb_Friend
drop table tb_Friend




Select * from tb_PersonalMessage
drop table tb_PersonalMessage


Select * from tb_RequestRelationship
drop table tb_RequestRelationship

drop table tb_Friend

Delete tb_WaitNewMatch;
Delete tb_chatRoom
Delete tb_Notification
Delete tb_PointMatch
DBCC CHECKIDENT ('tb_PointMatch', RESEED, 0)
Delete tb_MoveInMatch
Delete tb_Match;
DBCC CHECKIDENT ('tb_Match', RESEED, 0)
Delete tb_FindMatch;
DBCC CHECKIDENT ('tb_FindMatch', RESEED, 0)