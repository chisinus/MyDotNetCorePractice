using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyWebApi.FBEntities;

namespace MyWebApi.Models
{
    public partial class FBContext : DbContext
    {
        public FBContext()
        {
        }

        public FBContext(DbContextOptions<FBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCompany> TblCompanies { get; set; } = null!;
        public virtual DbSet<TblDictActivityType> TblDictActivityTypes { get; set; } = null!;
        public virtual DbSet<TblDictApplicationType> TblDictApplicationTypes { get; set; } = null!;
        public virtual DbSet<TblDictCompanyRole> TblDictCompanyRoles { get; set; } = null!;
        public virtual DbSet<TblDictControlType> TblDictControlTypes { get; set; } = null!;
        public virtual DbSet<TblDictGender> TblDictGenders { get; set; } = null!;
        public virtual DbSet<TblDictGroupType> TblDictGroupTypes { get; set; } = null!;
        public virtual DbSet<TblDictProjectRole> TblDictProjectRoles { get; set; } = null!;
        public virtual DbSet<TblDictSecurityQuestion> TblDictSecurityQuestions { get; set; } = null!;
        public virtual DbSet<TblDictStatus> TblDictStatuses { get; set; } = null!;
        public virtual DbSet<TblDictValueSource> TblDictValueSources { get; set; } = null!;
        public virtual DbSet<TblDictWebContactType> TblDictWebContactTypes { get; set; } = null!;
        public virtual DbSet<TblDictWebFaqtype> TblDictWebFaqtypes { get; set; } = null!;
        public virtual DbSet<TblGroup> TblGroups { get; set; } = null!;
        public virtual DbSet<TblGroupInputSet> TblGroupInputSets { get; set; } = null!;
        public virtual DbSet<TblInvitation> TblInvitations { get; set; } = null!;
        public virtual DbSet<TblProject> TblProjects { get; set; } = null!;
        public virtual DbSet<TblProjectControl> TblProjectControls { get; set; } = null!;
        public virtual DbSet<TblProjectInputSet> TblProjectInputSets { get; set; } = null!;
        public virtual DbSet<TblProjectPage> TblProjectPages { get; set; } = null!;
        public virtual DbSet<TblSysConfig> TblSysConfigs { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserActivity> TblUserActivities { get; set; } = null!;
        public virtual DbSet<TblUserCompany> TblUserCompanies { get; set; } = null!;
        public virtual DbSet<TblUserProject> TblUserProjects { get; set; } = null!;
        public virtual DbSet<TblUserWebPosition> TblUserWebPositions { get; set; } = null!;
        public virtual DbSet<TblWebContact> TblWebContacts { get; set; } = null!;
        public virtual DbSet<TblWebFaq> TblWebFaqs { get; set; } = null!;
        public virtual DbSet<VwCompany> VwCompanies { get; set; } = null!;
        public virtual DbSet<VwCompanyActive> VwCompanyActives { get; set; } = null!;
        public virtual DbSet<VwCompanyProject> VwCompanyProjects { get; set; } = null!;
        public virtual DbSet<VwCompanySummary> VwCompanySummaries { get; set; } = null!;
        public virtual DbSet<VwCurrent> VwCurrents { get; set; } = null!;
        public virtual DbSet<VwGroup> VwGroups { get; set; } = null!;
        public virtual DbSet<VwGroupActive> VwGroupActives { get; set; } = null!;
        public virtual DbSet<VwInvitation> VwInvitations { get; set; } = null!;
        public virtual DbSet<VwPageControl> VwPageControls { get; set; } = null!;
        public virtual DbSet<VwProject> VwProjects { get; set; } = null!;
        public virtual DbSet<VwProjectActive> VwProjectActives { get; set; } = null!;
        public virtual DbSet<VwProjectGroupSummary> VwProjectGroupSummaries { get; set; } = null!;
        public virtual DbSet<VwProjectPageSummary> VwProjectPageSummaries { get; set; } = null!;
        public virtual DbSet<VwProjectSummary> VwProjectSummaries { get; set; } = null!;
        public virtual DbSet<VwUser> VwUsers { get; set; } = null!;
        public virtual DbSet<VwUserActivity> VwUserActivities { get; set; } = null!;
        public virtual DbSet<VwUserCompany> VwUserCompanies { get; set; } = null!;
        public virtual DbSet<VwUserCompanyActive> VwUserCompanyActives { get; set; } = null!;
        public virtual DbSet<VwUserCompanyFull> VwUserCompanyFulls { get; set; } = null!;
        public virtual DbSet<VwUserProject> VwUserProjects { get; set; } = null!;
        public virtual DbSet<VwWebContact> VwWebContacts { get; set; } = null!;
        public virtual DbSet<VwWebFaq> VwWebFaqs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=FBConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("tblCompany");

                entity.HasIndex(e => e.CompanyName, "IX_tblCompany")
                    .IsUnique();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblCompanies)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCompany_tblDict_Status");
            });

            modelBuilder.Entity<TblDictActivityType>(entity =>
            {
                entity.HasKey(e => e.ActivityTypeId);

                entity.ToTable("tblDict_ActivityType");

                entity.Property(e => e.ActivityTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ActivityTypeID");

                entity.Property(e => e.ActivityTypeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictApplicationType>(entity =>
            {
                entity.HasKey(e => e.ApplicationTypeId);

                entity.ToTable("tblDict_ApplicationType");

                entity.Property(e => e.ApplicationTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ApplicationTypeID");

                entity.Property(e => e.ApplicationTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictCompanyRole>(entity =>
            {
                entity.HasKey(e => e.CompanyRoleId)
                    .HasName("PK_tblDict_Role");

                entity.ToTable("tblDict_CompanyRole");

                entity.Property(e => e.CompanyRoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("CompanyRoleID");

                entity.Property(e => e.CompanyRoleDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictControlType>(entity =>
            {
                entity.HasKey(e => e.ControlTypeId);

                entity.ToTable("tblDict_ControlType");

                entity.Property(e => e.ControlTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ControlTypeID");

                entity.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");

                entity.Property(e => e.ControlTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictGender>(entity =>
            {
                entity.HasKey(e => e.GenderTypeId);

                entity.ToTable("tblDict_Gender");

                entity.Property(e => e.GenderTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("GenderTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictGroupType>(entity =>
            {
                entity.HasKey(e => e.GroupTypeId);

                entity.ToTable("tblDict_GroupType");

                entity.Property(e => e.GroupTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("GroupTypeID");

                entity.Property(e => e.GroupTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictProjectRole>(entity =>
            {
                entity.HasKey(e => e.ProjectRoleId);

                entity.ToTable("tblDict_ProjectRole");

                entity.Property(e => e.ProjectRoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProjectRoleID");

                entity.Property(e => e.ProjectRoleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictSecurityQuestion>(entity =>
            {
                entity.HasKey(e => e.SecurityQuestionId);

                entity.ToTable("tblDict_SecurityQuestion");

                entity.Property(e => e.SecurityQuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("SecurityQuestionID");

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("tblDict_Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusID");

                entity.Property(e => e.StatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictValueSource>(entity =>
            {
                entity.HasKey(e => e.ValueSourceId)
                    .HasName("PK_tblDict_DataSource");

                entity.ToTable("tblDict_ValueSource");

                entity.Property(e => e.ValueSourceId)
                    .ValueGeneratedNever()
                    .HasColumnName("ValueSourceID");

                entity.Property(e => e.ValueSourceDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictWebContactType>(entity =>
            {
                entity.HasKey(e => e.ContactTypeId)
                    .HasName("PK_tblDict_ContactType");

                entity.ToTable("tblDict_Web_ContactType");

                entity.Property(e => e.ContactTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ContactTypeID");

                entity.Property(e => e.ContactTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDictWebFaqtype>(entity =>
            {
                entity.HasKey(e => e.FaqtypeId)
                    .HasName("PK_tblDict_FAQType");

                entity.ToTable("tblDict_Web_FAQType");

                entity.Property(e => e.FaqtypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("FAQTypeID");

                entity.Property(e => e.FaqtypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAQTypeDesc")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("tblGroup");

                entity.HasIndex(e => new { e.ProjectId, e.GroupName }, "IX_tblGroup");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupTypeId).HasColumnName("GroupTypeID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblGroups)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_tblUser");

                entity.HasOne(d => d.GroupType)
                    .WithMany(p => p.TblGroups)
                    .HasForeignKey(d => d.GroupTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_tblDict_GroupType");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblGroups)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_tblProject");
            });

            modelBuilder.Entity<TblGroupInputSet>(entity =>
            {
                entity.HasKey(e => e.GroupInputSetId);

                entity.ToTable("tblGroup_InputSet");

                entity.HasIndex(e => new { e.GroupId, e.InputSetId }, "IX_tblGroup_InputSet")
                    .IsUnique();

                entity.Property(e => e.GroupInputSetId).HasColumnName("GroupInputSetID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.InputSetId).HasColumnName("InputSetID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupInputSets)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_InputSet_tblGroup");

                entity.HasOne(d => d.InputSet)
                    .WithMany(p => p.TblGroupInputSets)
                    .HasForeignKey(d => d.InputSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_InputSet_tblProject_InputSet");
            });

            modelBuilder.Entity<TblInvitation>(entity =>
            {
                entity.HasKey(e => e.InvitationId);

                entity.ToTable("tblInvitation");

                entity.Property(e => e.InvitationId).HasColumnName("InvitationID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyRoleId).HasColumnName("CompanyRoleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.InvitedOn).HasColumnType("datetime");

                entity.Property(e => e.InviteeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectRoleId).HasColumnName("ProjectRoleID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblInvitations)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvitation_tblCompany");

                entity.HasOne(d => d.CompanyRole)
                    .WithMany(p => p.TblInvitations)
                    .HasForeignKey(d => d.CompanyRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvitation_tblDict_CompanyRole");

                entity.HasOne(d => d.InvitedByNavigation)
                    .WithMany(p => p.TblInvitations)
                    .HasForeignKey(d => d.InvitedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvitation_tblUser");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblInvitations)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvitation_tblProject");

                entity.HasOne(d => d.ProjectRole)
                    .WithMany(p => p.TblInvitations)
                    .HasForeignKey(d => d.ProjectRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvitation_tblDict_ProjectRole");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblInvitations)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvitation_tblDict_Status");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK_tblTeam");

                entity.ToTable("tblProject");

                entity.HasIndex(e => new { e.CompanyId, e.ProjectName }, "IX_tblProject")
                    .IsUnique();

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblProjects)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_tblCompany");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblProjects)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_tblDict_Status");
            });

            modelBuilder.Entity<TblProjectControl>(entity =>
            {
                entity.HasKey(e => e.ControlId);

                entity.ToTable("tblProject_Control");

                entity.Property(e => e.ControlId).HasColumnName("ControlID");

                entity.Property(e => e.ControlName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ControlTypeId).HasColumnName("ControlTypeID");

                entity.Property(e => e.InputSetId).HasColumnName("InputSetID");

                entity.Property(e => e.Value).HasColumnType("text");

                entity.Property(e => e.ValueSourceId).HasColumnName("ValueSourceID");

                entity.HasOne(d => d.ControlType)
                    .WithMany(p => p.TblProjectControls)
                    .HasForeignKey(d => d.ControlTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_Control_tblDict_ControlType");

                entity.HasOne(d => d.InputSet)
                    .WithMany(p => p.TblProjectControls)
                    .HasForeignKey(d => d.InputSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_Control_tblProject_InputSet");

                entity.HasOne(d => d.ValueSource)
                    .WithMany(p => p.TblProjectControls)
                    .HasForeignKey(d => d.ValueSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_Control_tblDict_DataSource");
            });

            modelBuilder.Entity<TblProjectInputSet>(entity =>
            {
                entity.HasKey(e => e.InputSetId);

                entity.ToTable("tblProject_InputSet");

                entity.HasIndex(e => new { e.PageId, e.InputSetName }, "IX_tblProject_InputSet")
                    .IsUnique();

                entity.Property(e => e.InputSetId).HasColumnName("InputSetID");

                entity.Property(e => e.InputSetName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.TblProjectInputSets)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_InputSet_tblProject_Page");
            });

            modelBuilder.Entity<TblProjectPage>(entity =>
            {
                entity.HasKey(e => e.PageId);

                entity.ToTable("tblProject_Page");

                entity.HasIndex(e => new { e.PageName, e.ProjectId }, "IX_tblProject_Page")
                    .IsUnique();

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.PageName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblProjectPages)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_Page_tblProject");
            });

            modelBuilder.Entity<TblSysConfig>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblSys_Config");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ScriptFolder)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CurrentGroupId).HasColumnName("CurrentGroupID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GenderTypeId).HasColumnName("GenderTypeID");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.GenderType)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.GenderTypeId)
                    .HasConstraintName("FK_tblUser_tblDict_Gender");
            });

            modelBuilder.Entity<TblUserActivity>(entity =>
            {
                entity.HasKey(e => e.UserActivityId);

                entity.ToTable("tblUser_Activity");

                entity.Property(e => e.UserActivityId).HasColumnName("UserActivityID");

                entity.Property(e => e.ActivityLog).HasColumnType("text");

                entity.Property(e => e.ActivityTime).HasColumnType("datetime");

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.TblUserActivities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Activity_tblDict_ActivityType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserActivities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Activity_tblUser");
            });

            modelBuilder.Entity<TblUserCompany>(entity =>
            {
                entity.HasKey(e => e.UserCompanyId)
                    .HasName("PK_tblCompany_User");

                entity.ToTable("tblUser_Company");

                entity.Property(e => e.UserCompanyId).HasColumnName("UserCompanyID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyJoinedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyRoleId).HasColumnName("CompanyRoleID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblUserCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Company_tblCompany");

                entity.HasOne(d => d.CompanyRole)
                    .WithMany(p => p.TblUserCompanies)
                    .HasForeignKey(d => d.CompanyRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Company_tblDict_CompanyRole");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblUserCompanies)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Company_tblDict_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserCompanies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Company_tblUser");
            });

            modelBuilder.Entity<TblUserProject>(entity =>
            {
                entity.HasKey(e => e.UserProjectId)
                    .HasName("PK_tblTeam_User");

                entity.ToTable("tblUser_Project");

                entity.Property(e => e.UserProjectId).HasColumnName("UserProjectID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectJoinedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectRoleId).HasColumnName("ProjectRoleID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblUserProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Project_tblProject");

                entity.HasOne(d => d.ProjectRole)
                    .WithMany(p => p.TblUserProjects)
                    .HasForeignKey(d => d.ProjectRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Project_tblDict_ProjectRole");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblUserProjects)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Project_tblDict_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Project_tblUser");
            });

            modelBuilder.Entity<TblUserWebPosition>(entity =>
            {
                entity.HasKey(e => e.CurrentId)
                    .HasName("PK_tblCurrentX");

                entity.ToTable("tblUser_WebPosition");

                entity.Property(e => e.CurrentId).HasColumnName("CurrentID");

                entity.Property(e => e.CurrentGroupId).HasColumnName("CurrentGroupID");

                entity.Property(e => e.CurrentUserId).HasColumnName("CurrentUserID");

                entity.Property(e => e.Wpid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WPID");

                entity.HasOne(d => d.CurrentUser)
                    .WithMany(p => p.TblUserWebPositions)
                    .HasForeignKey(d => d.CurrentUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCurrentX_tblUser");
            });

            modelBuilder.Entity<TblWebContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_tblContact");

                entity.ToTable("tblWeb_Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.TblWebContacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContact_tblDict_ContactType");
            });

            modelBuilder.Entity<TblWebFaq>(entity =>
            {
                entity.HasKey(e => e.Faqid)
                    .HasName("PK_tblFAQ");

                entity.ToTable("tblWeb_FAQ");

                entity.Property(e => e.Faqid).HasColumnName("FAQID");

                entity.Property(e => e.Faqdetails)
                    .HasColumnType("text")
                    .HasColumnName("FAQDetails");

                entity.Property(e => e.Faqtitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FAQTitle");

                entity.Property(e => e.FaqtypeId).HasColumnName("FAQTypeID");

                entity.HasOne(d => d.Faqtype)
                    .WithMany(p => p.TblWebFaqs)
                    .HasForeignKey(d => d.FaqtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFAQ_tblDict_FAQType");
            });

            modelBuilder.Entity<VwCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCompany");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyStatusId).HasColumnName("CompanyStatusID");
            });

            modelBuilder.Entity<VwCompanyActive>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCompany_Active");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyStatusId).HasColumnName("CompanyStatusID");
            });

            modelBuilder.Entity<VwCompanyProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCompany_Project");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ProjectCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectDeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");
            });

            modelBuilder.Entity<VwCompanySummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCompany_Summary");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyStatusId).HasColumnName("CompanyStatusID");
            });

            modelBuilder.Entity<VwCurrent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCurrent");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CurrentUserId).HasColumnName("CurrentUserID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Wpid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WPID");
            });

            modelBuilder.Entity<VwGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwGroup");

                entity.Property(e => e.GroupCreatedByFirstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupCreatedByLastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupTypeId).HasColumnName("GroupTypeID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            });

            modelBuilder.Entity<VwGroupActive>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwGroup_Active");

                entity.Property(e => e.GroupCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupTypeId).HasColumnName("GroupTypeID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            });

            modelBuilder.Entity<VwInvitation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwInvitation");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRoleDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyRoleId).HasColumnName("CompanyRoleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvitationId).HasColumnName("InvitationID");

                entity.Property(e => e.InvitedOn).HasColumnType("datetime");

                entity.Property(e => e.InviteeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectRoleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectRoleId).HasColumnName("ProjectRoleID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<VwPageControl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPage_Control");

                entity.Property(e => e.ControlId).HasColumnName("ControlID");

                entity.Property(e => e.ControlName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ControlTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ControlTypeId).HasColumnName("ControlTypeID");

                entity.Property(e => e.InputSetId).HasColumnName("InputSetID");

                entity.Property(e => e.Value).HasColumnType("text");

                entity.Property(e => e.ValueSourceDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValueSourceId).HasColumnName("ValueSourceID");
            });

            modelBuilder.Entity<VwProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProject");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ProjectCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectDeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");
            });

            modelBuilder.Entity<VwProjectActive>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProject_Active");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ProjectCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectDeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");
            });

            modelBuilder.Entity<VwProjectGroupSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProject_GroupSummary");

                entity.Property(e => e.GroupCreatedByFirstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupCreatedByLastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupTypeId).HasColumnName("GroupTypeID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            });

            modelBuilder.Entity<VwProjectPageSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProject_PageSummary");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.PageName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            });

            modelBuilder.Entity<VwProjectSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProject_Summary");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ProjectCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectDeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser");

                entity.Property(e => e.CurrentGroupId).HasColumnName("CurrentGroupID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SecurityQuestionAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");
            });

            modelBuilder.Entity<VwUserActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser_Activity");

                entity.Property(e => e.ActivityLog).HasColumnType("text");

                entity.Property(e => e.ActivityTime).HasColumnType("datetime");

                entity.Property(e => e.ActivityTypeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserActivityId).HasColumnName("UserActivityID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VwUserCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser_Company");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyJoinedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRemovedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyStatusId).HasColumnName("CompanyStatusID");

                entity.Property(e => e.CurrentGroupId).HasColumnName("CurrentGroupID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SecurityQuestionAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.UserCompanyId).HasColumnName("UserCompanyID");

                entity.Property(e => e.UserCompanyRoleDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserCompanyRoleId).HasColumnName("UserCompanyRoleID");

                entity.Property(e => e.UserCompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserCompanyStatusId).HasColumnName("UserCompanyStatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");
            });

            modelBuilder.Entity<VwUserCompanyActive>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser_Company_Active");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyJoinedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyStatusId).HasColumnName("CompanyStatusID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SecurityQuestionAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.UserCompanyId).HasColumnName("UserCompanyID");

                entity.Property(e => e.UserCompanyRoleDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserCompanyRoleId).HasColumnName("UserCompanyRoleID");

                entity.Property(e => e.UserCompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserCompanyStatusId).HasColumnName("UserCompanyStatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");
            });

            modelBuilder.Entity<VwUserCompanyFull>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser_Company_Full");

                entity.Property(e => e.CompanyCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyJoinedOn).HasColumnType("datetime");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRoleDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyRoleId).HasColumnName("CompanyRoleID");

                entity.Property(e => e.CompanyStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyStatusId).HasColumnName("CompanyStatusID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SecurityQuestionAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");
            });

            modelBuilder.Entity<VwUserProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser_Project");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CurrentGroupId).HasColumnName("CurrentGroupID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectDeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectJoinedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SecurityQuestionAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserProjectId).HasColumnName("UserProjectID");

                entity.Property(e => e.UserProjectRoleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserProjectRoleId).HasColumnName("UserProjectRoleID");

                entity.Property(e => e.UserProjectStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserProjectStatusId).HasColumnName("UserProjectStatusID");

                entity.Property(e => e.UserStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");
            });

            modelBuilder.Entity<VwWebContact>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwWeb_Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContactTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwWebFaq>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwWeb_FAQ");

                entity.Property(e => e.Faqdetails)
                    .HasColumnType("text")
                    .HasColumnName("FAQDetails");

                entity.Property(e => e.Faqid).HasColumnName("FAQID");

                entity.Property(e => e.Faqtitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FAQTitle");

                entity.Property(e => e.FaqtypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAQTypeDesc")
                    .IsFixedLength();

                entity.Property(e => e.FaqtypeId).HasColumnName("FAQTypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
