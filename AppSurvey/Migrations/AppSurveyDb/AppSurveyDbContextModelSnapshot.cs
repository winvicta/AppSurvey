using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AppSurvey.Data;

namespace AppSurvey.Migrations.AppSurveyDb
{
    [DbContext(typeof(AppSurveyDbContext))]
    partial class AppSurveyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppSurvey.Models.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int>("QID");

                    b.Property<int>("RecordID");

                    b.Property<string>("Text");

                    b.HasKey("AnswerID");

                    b.HasIndex("RecordID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("AppSurvey.Models.Option", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<int>("QuestionID");

                    b.Property<int>("Rank");

                    b.Property<bool>("Selected");

                    b.HasKey("OptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("AppSurvey.Models.OptionType", b =>
                {
                    b.Property<int>("OptionTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OptionID");

                    b.Property<int>("Rank");

                    b.Property<string>("Type");

                    b.HasKey("OptionTypeID");

                    b.HasIndex("OptionID");

                    b.ToTable("OptionTypes");
                });

            modelBuilder.Entity("AppSurvey.Models.Question", b =>
                {
                    b.Property<int>("QuestionID");

                    b.Property<string>("Description");

                    b.Property<int>("Index");

                    b.HasKey("QuestionID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AppSurvey.Models.Record", b =>
                {
                    b.Property<int>("RecordID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("StudentNumber");

                    b.HasKey("RecordID");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("AppSurvey.Models.Answer", b =>
                {
                    b.HasOne("AppSurvey.Models.Record", "Record")
                        .WithMany("Answers")
                        .HasForeignKey("RecordID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSurvey.Models.Option", b =>
                {
                    b.HasOne("AppSurvey.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSurvey.Models.OptionType", b =>
                {
                    b.HasOne("AppSurvey.Models.Option", "Option")
                        .WithMany("OptionTypes")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
