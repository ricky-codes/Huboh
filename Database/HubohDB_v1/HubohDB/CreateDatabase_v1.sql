CREATE DATABASE HubohDB_v1
on primary(
 NAME = 'HubohDBv1Data',
 FILENAME= 'C:\Users\ricar\Documents\Ricardo\Informática\Código\WPF C#\Huboh\Database\HubohDBv1Data.mdf',
 SIZE=5MB,
 MAXSIZE=UNLIMITED,
 FILEGROWTH=1MB
)
log on(
 NAME = 'HubohDBv1Log',
 FILENAME= 'C:\Users\ricar\Documents\Ricardo\Informática\Código\WPF C#\Huboh\Database\HubohDBv1Log.ldf',
 SIZE=5MB,
 MAXSIZE=UNLIMITED,
 FILEGROWTH=1MB
);