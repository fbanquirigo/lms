IF EXISTS(SELECT 1 FROM sysobjects WHERE [type] = 'P' AND name = 'ELMAH_LogError')
BEGIN
	DROP PROCEDURE ELMAH_LogError
END


IF EXISTS(SELECT 1 FROM sysobjects WHERE [type] = 'P' AND name = 'ELMAH_GetErrorsXml')
BEGIN
	DROP PROCEDURE ELMAH_GetErrorsXml
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE [type]= 'P' AND name = 'ELMAH_GetErrorXml')
BEGIN
	DROP PROCEDURE ELMAH_GetErrorXml
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE [type] = 'U' AND name = 'ELMAH_Error')
BEGIN
	DROP TABLE ELMAH_Error
END