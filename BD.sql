CREATE DATABASE JSANCHEZCRUDPERSONAS
USE JSANCHEZCRUDPERSONAS
GO

CREATE TABLE PERSONA
(
IDPERSONA INT IDENTITY(1,1) PRIMARY KEY,
NOMRRE VARCHAR(250) NOT NULL,
APELLIDOPATERNO VARCHAR(250) NOT NULL,
APELLIDOMATERNO VARCHAR(250) NOT NULL
)
GO

CREATE PROCEDURE PersonaAdd --'Jose','Sanchez','Xihuitl'
@NOMBRE VARCHAR(250),
@APELLIDOPATERNO VARCHAR(250),
@APELLIDOMATERNO VARCHAR(250)
AS
INSERT INTO PERSONA (NOMRRE,APELLIDOPATERNO,APELLIDOMATERNO)
VALUES (@NOMBRE,@APELLIDOPATERNO,@APELLIDOMATERNO)
GO

CREATE PROCEDURE PersonaUpdate
@IDPERSONA INT,
@NOMBRE VARCHAR(250),
@APELLIDOPATERNO VARCHAR(250),
@APELLIDOMATERNO VARCHAR(250)
AS
UPDATE PERSONA SET NOMRRE=@NOMBRE,APELLIDOPATERNO=@APELLIDOPATERNO,APELLIDOMATERNO=@APELLIDOMATERNO
WHERE IDPERSONA=@IDPERSONA
GO

CREATE PROCEDURE PersonaDelete
@IDPERSONA INT
AS
DELETE FROM PERSONA WHERE IDPERSONA=@IDPERSONA
GO

CREATE PROCEDURE PersonaGetAll
AS
SELECT IDPERSONA,NOMRRE,APELLIDOPATERNO,APELLIDOMATERNO FROM PERSONA
GO

CREATE PROCEDURE PersonaGetById
@IDPERSONA INT
AS
SELECT IDPERSONA,NOMRRE,APELLIDOPATERNO,APELLIDOMATERNO FROM PERSONA 
WHERE IDPERSONA=@IDPERSONA
GO
