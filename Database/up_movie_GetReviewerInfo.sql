
-- =============================================
-- Author:		Craig
-- Create date: 3/1/19
-- Description:	Get Reviewer Info
-- =============================================
CREATE PROCEDURE [dbo].[up_movie_GetReviewerInfo]
	@id INT
AS
BEGIN
	SELECT
		u.FirstName,
		(SELECT 
			COUNT(mr.id_Reviewer) 
		FROM movie_Review mr
		WHERE mr.id_Reviewer = u.id_user) as 'Reviews'
	FROM core_User u
	WHERE u.id_User = @id
END
GO