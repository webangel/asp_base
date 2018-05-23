namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Hobby : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Hobby_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hobbies", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hobbies", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hobbies", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Hobbies", new[] { "DeletedBy" });
            DropIndex("dbo.Hobbies", new[] { "UpdatedBy" });
            DropIndex("dbo.Hobbies", new[] { "CreatedBy" });
            DropTable("dbo.Hobbies",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Hobby_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
