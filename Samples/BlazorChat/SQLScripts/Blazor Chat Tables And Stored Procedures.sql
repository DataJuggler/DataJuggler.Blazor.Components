USE [BlazorSample]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](80) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[EmailVerified] [bit] NULL,
	[TotalLogins] [int] NULL,
	[Premium] [bit] NULL,
	[PremiumExpires] [datetime] NULL,
	[IsAdmin] [bit] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_EmailVerified]  DEFAULT ((0)) FOR [EmailVerified]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_TotalLogins]  DEFAULT ((0)) FOR [TotalLogins]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Premium]  DEFAULT ((0)) FOR [Premium]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [User]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_FetchAll]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[Premium],[PremiumExpires],[TotalLogins],[UserName]

    -- From tableName
    From [User]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_Find]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[Premium],[PremiumExpires],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_FindByEmailAddress]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_FindByEmailAddress]

    -- Create @EmailAddress Paramater
    @EmailAddress nvarchar(80)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[Premium],[PremiumExpires],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [EmailAddress] = @EmailAddress

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_FindByUserName]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_FindByUserName]

    -- Create @UserName Paramater
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[Premium],[PremiumExpires],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [UserName] = @UserName

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Insert]

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @EmailVerified bit,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @Premium bit,
    @PremiumExpires datetime,
    @TotalLogins int,
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [User]
    ([Active],[CreatedDate],[EmailAddress],[EmailVerified],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[Premium],[PremiumExpires],[TotalLogins],[UserName])

    -- Begin Values List
    Values(@Active, @CreatedDate, @EmailAddress, @EmailVerified, @IsAdmin, @LastLoginDate, @Name, @PasswordHash, @Premium, @PremiumExpires, @TotalLogins, @UserName)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 6/1/2020 5:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Update]

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @EmailVerified bit,
    @Id int,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @Premium bit,
    @PremiumExpires datetime,
    @TotalLogins int,
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [User]

    -- Update Each field
    Set [Active] = @Active,
    [CreatedDate] = @CreatedDate,
    [EmailAddress] = @EmailAddress,
    [EmailVerified] = @EmailVerified,
    [IsAdmin] = @IsAdmin,
    [LastLoginDate] = @LastLoginDate,
    [Name] = @Name,
    [PasswordHash] = @PasswordHash,
    [Premium] = @Premium,
    [PremiumExpires] = @PremiumExpires,
    [TotalLogins] = @TotalLogins,
    [UserName] = @UserName

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
