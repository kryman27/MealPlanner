using EnumStringValues;
enum LoggerInfo
{
	[StringValue("Product found successfully")]
	ProductFound,
	
	[StringValue("Error")]
	Error,
	
	[StringValue("Product added successfully")]
	ProductAdded,
	
	[StringValue("Deleted successfully")]
	Deleted,

	[StringValue("Updated successfully")]
	Updated,

	[StringValue("Custom meal found successfully")]
	CustomMealFound,

    [StringValue("Custom meal added successfully")]
    CustomMealAdded,

    [StringValue("User preferences added successfully")]
    UserPreferencesAdded
}