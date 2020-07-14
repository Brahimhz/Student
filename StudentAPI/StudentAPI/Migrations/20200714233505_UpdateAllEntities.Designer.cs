﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAPI.Persistance;

namespace StudentAPI.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20200714233505_UpdateAllEntities")]
    partial class UpdateAllEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentAPI.Core.Models.Bloc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EtablissementId");

                    b.Property<string>("RefBloc");

                    b.HasKey("Id");

                    b.HasIndex("EtablissementId");

                    b.ToTable("Blocs");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EtablissementId");

                    b.Property<string>("NomDepartement");

                    b.Property<int?>("RespCommunicationId");

                    b.HasKey("Id");

                    b.HasIndex("EtablissementId");

                    b.HasIndex("RespCommunicationId")
                        .IsUnique()
                        .HasFilter("[RespCommunicationId] IS NOT NULL");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Discussion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateDebut");

                    b.Property<DateTime?>("DateFin");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("RelationCommunicationId");

                    b.HasKey("Id");

                    b.HasIndex("RelationCommunicationId");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.DocumentFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocumentPartageId");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DocumentPartageId")
                        .IsUnique();

                    b.ToTable("DocumentFiles");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.DocumentPartage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int?>("MatiereRefId");

                    b.Property<int?>("NiveauSpecialiteId");

                    b.Property<string>("NomDoc");

                    b.Property<int>("PersonneId");

                    b.Property<string>("TypeDoc");

                    b.HasKey("Id");

                    b.HasIndex("MatiereRefId");

                    b.HasIndex("NiveauSpecialiteId");

                    b.HasIndex("PersonneId");

                    b.ToTable("DocumentPartages");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.DomaineFormation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartementId");

                    b.Property<string>("DescriptionDF");

                    b.Property<int>("FormationId");

                    b.Property<string>("NomDF");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.HasIndex("FormationId");

                    b.ToTable("DomaineFormations");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Etablissement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomEtablissement");

                    b.HasKey("Id");

                    b.ToTable("Etablissements");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Filiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionFiliere");

                    b.Property<int>("DomaineFormationId");

                    b.Property<string>("NomFiliere");

                    b.HasKey("Id");

                    b.HasIndex("DomaineFormationId");

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Systeme");

                    b.Property<string>("TypeFormation");

                    b.HasKey("Id");

                    b.ToTable("Formations");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RefGroupe");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.InfoSeance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EnseignatId");

                    b.Property<int>("JourneeId");

                    b.Property<int>("MatiereId");

                    b.Property<int>("PlanningId");

                    b.Property<int?>("SalleId");

                    b.Property<int>("SeanceId");

                    b.Property<string>("Type");

                    b.HasKey("id");

                    b.HasIndex("JourneeId");

                    b.HasIndex("MatiereId");

                    b.HasIndex("PlanningId");

                    b.HasIndex("SalleId");

                    b.HasIndex("SeanceId");

                    b.HasIndex("EnseignatId", "JourneeId", "SeanceId", "SalleId")
                        .IsUnique()
                        .HasFilter("[EnseignatId] IS NOT NULL AND [SalleId] IS NOT NULL");

                    b.ToTable("InfoSeances");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Journee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Jour");

                    b.HasKey("Id");

                    b.ToTable("Journees");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Matiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Coefficient");

                    b.Property<double>("Credit");

                    b.Property<int>("MatiereRefId");

                    b.Property<int>("NiveauSpecialiteId");

                    b.Property<int>("UnitePedagogiqueId");

                    b.HasKey("Id");

                    b.HasIndex("MatiereRefId");

                    b.HasIndex("NiveauSpecialiteId");

                    b.HasIndex("UnitePedagogiqueId");

                    b.ToTable("Matieres");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.MatiereRef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abrevation");

                    b.Property<string>("Description");

                    b.Property<string>("NomMatiere");

                    b.HasKey("Id");

                    b.ToTable("MatiereRefs");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateMsg");

                    b.Property<int>("DiscussionId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.NiveauSpecialite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Niveau");

                    b.Property<int>("SpecialiteId");

                    b.HasKey("Id");

                    b.HasIndex("SpecialiteId");

                    b.ToTable("NiveauSpecialites");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Parcour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EtudientId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("NiveauSpecialiteId");

                    b.Property<int?>("ResultatId");

                    b.Property<int?>("SousGroupeId");

                    b.HasKey("Id");

                    b.HasIndex("EtudientId");

                    b.HasIndex("NiveauSpecialiteId");

                    b.HasIndex("ResultatId")
                        .IsUnique()
                        .HasFilter("[ResultatId] IS NOT NULL");

                    b.HasIndex("SousGroupeId");

                    b.ToTable("Parcours");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Genre");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Nom");

                    b.Property<string>("Prenom");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("Personne");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personne");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Planning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdate");

                    b.HasKey("Id");

                    b.ToTable("Planning");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Planning");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.RelationCommunication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonneId1");

                    b.Property<int>("PersonneId2");

                    b.HasKey("Id");

                    b.HasIndex("PersonneId2");

                    b.HasIndex("PersonneId1", "PersonneId2")
                        .IsUnique();

                    b.ToTable("RelationCommunications");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Resultat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acquit");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<double?>("MoyenneFinal");

                    b.Property<int>("ParcourId");

                    b.Property<double?>("Total");

                    b.Property<double?>("TotalCoff");

                    b.Property<double?>("TotalCredit");

                    b.HasKey("Id");

                    b.ToTable("Resultats");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.ResultatMatiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acquit");

                    b.Property<double?>("CreditMatiere");

                    b.Property<int>("MatiereId");

                    b.Property<double?>("MoyenneMatiere");

                    b.Property<double?>("NoteControl");

                    b.Property<double?>("NoteExamen");

                    b.Property<int>("ResultatUniteId");

                    b.Property<double?>("TotalMatiere");

                    b.HasKey("Id");

                    b.HasIndex("MatiereId");

                    b.HasIndex("ResultatUniteId");

                    b.ToTable("ResultatMatieres");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.ResultatUnite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acquit");

                    b.Property<double?>("CreditUnite");

                    b.Property<double?>("MoyenneUnite");

                    b.Property<int>("ResultatId");

                    b.Property<double?>("TotalCoff");

                    b.Property<double?>("TotalUnite");

                    b.Property<int>("UnitePedagogiqueId");

                    b.HasKey("Id");

                    b.HasIndex("ResultatId");

                    b.HasIndex("UnitePedagogiqueId");

                    b.ToTable("ResultatUnites");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Salle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlocId");

                    b.Property<string>("RefSalle");

                    b.Property<string>("TypeSalle");

                    b.HasKey("Id");

                    b.HasIndex("BlocId");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Seance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Heure");

                    b.HasKey("Id");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NiveauSpecialiteId");

                    b.Property<string>("RefSection");

                    b.HasKey("Id");

                    b.HasIndex("NiveauSpecialiteId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.SousGroupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupeId");

                    b.Property<string>("RefSousGroupe");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("SousGroupes");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Specialite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Durée");

                    b.Property<int>("FiliereId");

                    b.Property<string>("NomSpecialite");

                    b.HasKey("Id");

                    b.HasIndex("FiliereId");

                    b.ToTable("Specialites");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.UnitePedagogique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeUnite");

                    b.HasKey("Id");

                    b.ToTable("UnitePedagogiques");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Enseignant", b =>
                {
                    b.HasBaseType("StudentAPI.Core.Models.Personne");

                    b.Property<string>("Grade");

                    b.ToTable("Enseignant");

                    b.HasDiscriminator().HasValue("Enseignant");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Etudiant", b =>
                {
                    b.HasBaseType("StudentAPI.Core.Models.Personne");

                    b.Property<string>("Matricule");

                    b.ToTable("Etudiant");

                    b.HasDiscriminator().HasValue("Etudiant");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.RespCommunication", b =>
                {
                    b.HasBaseType("StudentAPI.Core.Models.Personne");

                    b.Property<int>("DepartementId");

                    b.ToTable("RespCommunication");

                    b.HasDiscriminator().HasValue("RespCommunication");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.PlanningGroupe", b =>
                {
                    b.HasBaseType("StudentAPI.Core.Models.Planning");

                    b.Property<int>("GroupeId");

                    b.Property<int>("PlanningSectionId");

                    b.HasIndex("GroupeId");

                    b.HasIndex("PlanningSectionId");

                    b.ToTable("PlanningGroupe");

                    b.HasDiscriminator().HasValue("PlanningGroupe");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.PlanningSection", b =>
                {
                    b.HasBaseType("StudentAPI.Core.Models.Planning");

                    b.Property<int>("SectionId");

                    b.Property<string>("Type");

                    b.HasIndex("SectionId");

                    b.ToTable("PlanningSection");

                    b.HasDiscriminator().HasValue("PlanningSection");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.PlanningSGroupe", b =>
                {
                    b.HasBaseType("StudentAPI.Core.Models.Planning");

                    b.Property<int>("PlanningGroupeId");

                    b.Property<int>("SousGroupeId");

                    b.HasIndex("PlanningGroupeId");

                    b.HasIndex("SousGroupeId");

                    b.ToTable("PlanningSGroupe");

                    b.HasDiscriminator().HasValue("PlanningSGroupe");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Bloc", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Etablissement", "Etablissement")
                        .WithMany("Blocs")
                        .HasForeignKey("EtablissementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Departement", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Etablissement", "Etablissement")
                        .WithMany("Departements")
                        .HasForeignKey("EtablissementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.RespCommunication", "RespCommunication")
                        .WithOne("Departement")
                        .HasForeignKey("StudentAPI.Core.Models.Departement", "RespCommunicationId");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Discussion", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.RelationCommunication", "RelationCommunication")
                        .WithMany("Discussions")
                        .HasForeignKey("RelationCommunicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.DocumentFile", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.DocumentPartage")
                        .WithOne("Document")
                        .HasForeignKey("StudentAPI.Core.Models.DocumentFile", "DocumentPartageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.DocumentPartage", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.MatiereRef", "MatiereRef")
                        .WithMany("DocumentPartages")
                        .HasForeignKey("MatiereRefId");

                    b.HasOne("StudentAPI.Core.Models.NiveauSpecialite", "NiveauSpecialite")
                        .WithMany("DocumentPartages")
                        .HasForeignKey("NiveauSpecialiteId");

                    b.HasOne("StudentAPI.Core.Models.Personne", "Personne")
                        .WithMany("DocumentPartages")
                        .HasForeignKey("PersonneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.DomaineFormation", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Departement", "Departement")
                        .WithMany("DomaineFormations")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.Formation", "Formation")
                        .WithMany("DomaineFormations")
                        .HasForeignKey("FormationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Filiere", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.DomaineFormation", "DomaineFormation")
                        .WithMany("Filieres")
                        .HasForeignKey("DomaineFormationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Groupe", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Section", "Section")
                        .WithMany("Groupes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.InfoSeance", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Enseignant", "Enseignat")
                        .WithMany("InfoSeances")
                        .HasForeignKey("EnseignatId");

                    b.HasOne("StudentAPI.Core.Models.Journee", "Journee")
                        .WithMany("InfoSeances")
                        .HasForeignKey("JourneeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.Matiere", "Matiere")
                        .WithMany("InfoSeances")
                        .HasForeignKey("MatiereId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.Planning", "Planning")
                        .WithMany("InfoSeances")
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.Salle", "Salle")
                        .WithMany("InfoSeances")
                        .HasForeignKey("SalleId");

                    b.HasOne("StudentAPI.Core.Models.Seance", "Seance")
                        .WithMany("InfoSeances")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Matiere", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.MatiereRef", "MatiereRef")
                        .WithMany("Matieres")
                        .HasForeignKey("MatiereRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.NiveauSpecialite", "NiveauSpecialite")
                        .WithMany("Matieres")
                        .HasForeignKey("NiveauSpecialiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.UnitePedagogique", "UnitePedagogique")
                        .WithMany("Matieres")
                        .HasForeignKey("UnitePedagogiqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Message", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Discussion", "Discussion")
                        .WithMany("Messages")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.NiveauSpecialite", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Specialite", "Specialite")
                        .WithMany("NiveauSpecialites")
                        .HasForeignKey("SpecialiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Parcour", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Etudiant", "Etudient")
                        .WithMany("Parcours")
                        .HasForeignKey("EtudientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.NiveauSpecialite", "NiveauSpecialite")
                        .WithMany("Parcours")
                        .HasForeignKey("NiveauSpecialiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.Resultat", "Resultat")
                        .WithOne("Parcour")
                        .HasForeignKey("StudentAPI.Core.Models.Parcour", "ResultatId");

                    b.HasOne("StudentAPI.Core.Models.SousGroupe", "SousGroupe")
                        .WithMany("Parcours")
                        .HasForeignKey("SousGroupeId");
                });

            modelBuilder.Entity("StudentAPI.Core.Models.RelationCommunication", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Personne", "Personne1")
                        .WithMany("RelationCommunications1")
                        .HasForeignKey("PersonneId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StudentAPI.Core.Models.Personne", "Personne2")
                        .WithMany("RelationCommunications2")
                        .HasForeignKey("PersonneId2")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.ResultatMatiere", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Matiere", "Matiere")
                        .WithMany("ResultatMatieres")
                        .HasForeignKey("MatiereId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.ResultatUnite", "ResultatUnite")
                        .WithMany("ResultatMatieres")
                        .HasForeignKey("ResultatUniteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.ResultatUnite", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Resultat", "Resultat")
                        .WithMany("ResultatUnites")
                        .HasForeignKey("ResultatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentAPI.Core.Models.UnitePedagogique", "UnitePedagogique")
                        .WithMany("ResultatUnites")
                        .HasForeignKey("UnitePedagogiqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Salle", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Bloc", "Bloc")
                        .WithMany("Salles")
                        .HasForeignKey("BlocId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Section", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.NiveauSpecialite", "NiveauSpecialite")
                        .WithMany("Sections")
                        .HasForeignKey("NiveauSpecialiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.SousGroupe", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Groupe", "Groupe")
                        .WithMany("SousGroupes")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.Specialite", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Filiere", "Filiere")
                        .WithMany("Specialites")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.PlanningGroupe", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Groupe", "Groupe")
                        .WithMany("PlanningGroupes")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StudentAPI.Core.Models.PlanningSection", "PlanningSection")
                        .WithMany("PlanningGroupes")
                        .HasForeignKey("PlanningSectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.PlanningSection", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.Section", "Section")
                        .WithMany("PlanningSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentAPI.Core.Models.PlanningSGroupe", b =>
                {
                    b.HasOne("StudentAPI.Core.Models.PlanningGroupe", "PlanningGroupe")
                        .WithMany("PlanningSGroupes")
                        .HasForeignKey("PlanningGroupeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StudentAPI.Core.Models.SousGroupe", "SousGroupe")
                        .WithMany("PlanningSGroupes")
                        .HasForeignKey("SousGroupeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
