USE [INT]
GO

Create or ALTER PROCEDURE [dbo].[sp_GetUserDetails]
@UserId bigint=null
AS
BEGIN

	SET NOCOUNT ON;

	select U.Id,U.Name,U.NameHi,U.Email,U.UserName,Cu.Name CreatedBy,U.CreatedOn,U.IsDeleted ,Up.LastModifiedBy,Up.LastModifiedOn,
	dbo.fn_GetUserRoles(U.Id) as UserRoles
	from [User] U with(nolock)
	inner join [User] CU with(nolock) on(CU.Id=U.CreatedBy)
	left join  [User] UP with(nolock) on(UP.Id=U.LastModifiedBy)
	where U.IsDeleted=0 and (@UserId is null or U.Id=@UserId) 
END
Go
