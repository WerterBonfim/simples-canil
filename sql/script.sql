use master
go

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CanilDB')
  BEGIN
        CREATE DATABASE [CanilDB]
  END
GO

USE [CanilDB]
GO


create table TB_Clientes
(
    Id             uniqueidentifier not null
        constraint TB_Clientes_pk
            primary key nonclustered,
    Nome           varchar(50),
    DataNascimento date,
    CPF            varchar(15)
)
go

create unique index TB_Clientes_Id_uindex
    on TB_Clientes (Id)
go


create table TB_Caes
(
    Id        uniqueidentifier not null
        constraint TB_Caes_pk
            primary key nonclustered,
    Nome      varchar(30),
    Raca      varchar(30),
    ClienteId uniqueidentifier
        constraint TB_Caes_TB_Clientes_Id_fk
            references TB_Clientes
            on delete set null
)
go

create unique index TB_Caes_Id_uindex
    on TB_Caes (Id)
go




