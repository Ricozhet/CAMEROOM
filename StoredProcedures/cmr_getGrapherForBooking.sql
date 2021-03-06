USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getPlaceListByProvinceID]    Script Date: 08/06/2013 11:56:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sutatpan Vi.
-- Create date: 08/Jun/2013 11:56
-- =============================================
-- exec cmr_getGrapherForBooking '',1,1,2,1
ALTER PROCEDURE [dbo].[cmr_getGrapherForBooking]
@bookingDatetime datetime,
@bookingTypeID int,
@eventType int,
@provinceID int,
@placeID bigint
AS
BEGIN

	SET NOCOUNT ON;

	SELECT gp.GRAPHERID, gp.PHOTO
	FROM [dbo].[TBL_GRAPHER] gp
	LEFT JOIN [dbo].[TBL_MAPPROVINCE] mp ON gp.[GRAPHERID] = mp.[GRAPHERID]
	LEFT JOIN [dbo].[TBL_EARNINGRATE] er ON gp.[GRAPHERID] = er.[GRAPHERID]
	WHERE NOT EXISTS
	(
		SELECT bi.[GRAPHERID]
		FROM [dbo].[TBL_BOOKING] bi
		LEFT JOIN [dbo].[TBL_MAPPLACE] pl ON bi.[GRAPHERID] = pl.[GRAPHERID]
		WHERE bi.[BOOKINGDATETIME] = @bookingDatetime
		AND bi.[BOOKINGTYPEID] = @bookingTypeID
		AND pl.[PLACEID] = @placeID
	)
	AND mp.[PROVINCEID] = @provinceID
	AND er.[EVENTTYPEID] = @eventType


END

