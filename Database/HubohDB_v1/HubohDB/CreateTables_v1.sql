-- Parent Table
use HubohDB_v1;

create table FilePaths(
	filePathID int identity(1,1) primary key,
	fileFilename varchar(200) not null unique,
	fileDirectory varchar(200) not null,
	fileFullpath varchar(200)	
);

-- Parent Table
create table Composers(
	composerID int identity(1,1) primary key,
	composerName varchar(50) unique,
);

-- Parent Table
create table Genres(
	genreID int identity(1,1) primary key,
	genreDescription varchar(20) unique,
);

-- Parent Table
create table Lyrics(
	lyricsID int identity(1,1) primary key,
	lyrics varchar(500) unique,
);

-- Child Table
create table Songs(
	songID int identity(1,1) primary key,
	title varchar(120) unique,
	trackNumber int,
	songYear int,
	bpm int,
	lyricsID int,
	filepathID int,
	foreign key (lyricsID) references Lyrics(lyricsID)
		on delete cascade
		on update cascade,
	foreign key (filepathID) references FilePaths(filepathID) 
		on delete cascade 
		on update cascade
);

create table Publishers(
	publisherID int identity(1,1) primary key,
	publisherName varchar(50) unique
);

create table Artists(
	artistID int identity(1,1) primary key,
	artistName varchar(70) unique not null,
	birthday date,
	albumCount int,
	publisherID int,
	foreign key (publisherID) references Publishers(publisherID)
		on delete set null
		on update cascade
);


create table Albums(
	albumID int identity(1,1) primary key,
	albumName varchar(50) unique not null,
	trackCount int,
	releaseYear int
);


create table Composers_Songs(
	composers_SongsID int identity(1,1) primary key,
	composerID int,
	songID int,
	foreign key (composerID) references Composers(composerID)
		on delete cascade
		on update cascade,
	foreign key (songID) references Songs(songID)
		on update cascade
		on delete cascade
);


create table Artist_Songs(
	artist_SongsID int identity(1,1) primary key,
	songID int,
	artistID int, 
	foreign key (songID) references Songs(songID)
		on update cascade
		on delete cascade,
	foreign key (artistID) references Artists(artistID)
		on update cascade
		on delete cascade
);


create table Artists_Albums(
	artist_AlbumID int identity(1,1) primary key,
	albumID int,
	artistID int, 
	foreign key (albumID) references Albums(albumID)
		on update cascade
		on delete cascade,
	foreign key (artistID) references Artists(artistID)
		on update cascade
		on delete cascade
);


create table Genres_Songs(
	genres_songsID int identity(1,1) primary key,
	genreID int,
	songID int,
	foreign key (genreID) references Genres(genreID)
		on update cascade
		on delete cascade,
	foreign key (songID) references Songs(songID)
		on update cascade
		on delete cascade
);
