USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getPlaceListByProvinceID]    Script Date: 07/06/2013 20:02:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sutatpan Vi. 
-- Create date: 20/Apr/2013 16:16
-- =============================================
-- exec cmr_getPlaceListByProvinceID '3'
ALTER PROCEDURE [dbo].[cmr_getPlaceListByProvinceID]
(@provinceID bigint)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT PLACEID,PLACENAME FROM TBL_PLACE WHERE PROVINCEID = @provinceID
END
