USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getProvinceList]    Script Date: 07/06/2013 20:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sutatpan Vi.
-- Create date: 20/Apr/2013 16:14 
-- =============================================

ALTER PROCEDURE [dbo].[cmr_getProvinceList]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TBL_PROVINCE
END
