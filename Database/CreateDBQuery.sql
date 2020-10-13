CREATE DATABASE HubohDB
on primary(
 NAME = 'HubohDBData',
 FILENAME= 'C:\Users\ricar\Documents\Ricardo\Informática\Código\WPF C#\Huboh\Database\HubohDBData.mdf',
 SIZE=5MB,
 MAXSIZE=UNLIMITED,
 FILEGROWTH=1MB
)
log on(
 NAME = 'HubohDBLog',
 FILENAME= 'C:\Users\ricar\Documents\Ricardo\Informática\Código\WPF C#\Huboh\Database\HubohDBLog.ldf',
 SIZE=5MB,
 MAXSIZE=UNLIMITED,
 FILEGROWTH=1MB
)