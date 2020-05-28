Use [MemberSample]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Insert a new User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Insert >>>'

    End

GO

Create PROCEDURE User_Insert

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
Go
-- =========================================================
-- Procure Name: User_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Update an existing User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Update >>>'

    End

GO

Create PROCEDURE User_Update

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
Go
-- =========================================================
-- Procure Name: User_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Find an existing User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Find >>>'

    End

GO

Create PROCEDURE User_Find

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
Go
-- =========================================================
-- Procure Name: User_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Delete an existing User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Delete >>>'

    End

GO

Create PROCEDURE User_Delete

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
Go
-- =========================================================
-- Procure Name: User_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Returns all User objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_FetchAll >>>'

    End

GO

Create PROCEDURE User_FetchAll

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
Go
-- =========================================================
-- Procure Name: User_FindByEmailAddress
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Find an existing User for the EmailAddress given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_FindByEmailAddress'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_FindByEmailAddress

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_FindByEmailAddress') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_FindByEmailAddress >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_FindByEmailAddress >>>'

    End

GO

Create PROCEDURE User_FindByEmailAddress

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
Go
-- =========================================================
-- Procure Name: User_FindByUserName
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/30/2020
-- Description:    Find an existing User for the UserName given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_FindByUserName'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_FindByUserName

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_FindByUserName') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_FindByUserName >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_FindByUserName >>>'

    End

GO

Create PROCEDURE User_FindByUserName

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

