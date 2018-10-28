CREATE PROCEDURE SP_USER_QRY
AS
	BEGIN
		SELECT [UserId], [Username], [Password] FROM dbo.Users  
	END
GO
CREATE PROCEDURE SP_USER_DEL
(
	@UserId AS INTEGER
)
AS
	BEGIN
		DELETE FROM dbo.Users WHERE UserId = @UserId
	END
GO

CREATE PROCEDURE SP_USER_SEL
(
	@UserId AS INTEGER
)
AS
	BEGIN
		SELECT [UserId], [Username], [Password] FROM dbo.Users WHERE UserId = @UserId
	END
GO

CREATE PROCEDURE SP_USER_INS
(
	@Username AS VARCHAR(100),
	@Password AS VARCHAR(100), 
	@UserId AS INTEGER OUTPUT
)
AS
	BEGIN
		INSERT INTO dbo.Users ([Username], [Password]) 
		VALUES (@Username, @Password)
		SET @UserId = SCOPE_IDENTITY()
	END
GO

CREATE PROCEDURE SP_USER_UPD
(
	@UserId AS INTEGER,
	@Username AS VARCHAR(100),
	@Password AS VARCHAR(100)
)
AS
	BEGIN
		UPDATE dbo.Users 
		SET [Username] = @Username, [Password] = @Password
		WHERE UserId = @UserId
	END
GO