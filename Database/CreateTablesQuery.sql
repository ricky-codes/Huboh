use HubohDB;

create table song(
	id int identity(1,1) primary key,
	fileIndex int,
	title varchar(120),
	artist varchar(120),
	albumName varchar(120),
	sourceDirectory varchar(200) not null,
	musicFilename varchar(200) not null,
	musicCompletePath varchar(300) not null,
);


create table playlist(
	playlistIndex int identity(1,1) primary key not null,
	playlistName varchar(120) not null,
	playlistMusicCount int,
);

create table playlist_song(
	id int identity(1,1) primary key not null,
	music int foreign key references song(id),
	playlist int foreign key references playlist(playlistIndex),
);