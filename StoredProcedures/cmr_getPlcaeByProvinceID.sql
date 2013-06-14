USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getProvinceList]    Script Date: 08/06/2013 09:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sutatpan Vi.
-- Create date: 08/Jun/2013 09:23
-- =============================================

CREATE PROCEDURE [dbo].[cmr_getPlcaeByProvinceID]
@provinceID varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[TBL_PLACE]
	WHERE PROVINCEID = @provinceID
END

