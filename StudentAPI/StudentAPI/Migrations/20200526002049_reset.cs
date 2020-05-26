using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etablissements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomEtablissement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Systeme = table.Column<string>(nullable: true),
                    TypeFormation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatiereRefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomMatiere = table.Column<string>(nullable: true),
                    Abrevation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatiereRefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    Matricule = table.Column<string>(nullable: true),
                    DepartementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resultats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoyenneFinal = table.Column<double>(nullable: true),
                    Credit = table.Column<double>(nullable: true),
                    ParcourId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitePedagogiques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeUnite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitePedagogiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefBloc = table.Column<string>(nullable: true),
                    EtablissementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocs_Etablissements_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "Etablissements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomDepartement = table.Column<string>(nullable: true),
                    EtablissementId = table.Column<int>(nullable: false),
                    RespCommunicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departements_Etablissements_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "Etablissements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departements_Personne_RespCommunicationId",
                        column: x => x.RespCommunicationId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentPartages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomDoc = table.Column<string>(nullable: true),
                    TypeDoc = table.Column<string>(nullable: true),
                    PersonneId = table.Column<int>(nullable: false),
                    MatiereRefId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentPartages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentPartages_MatiereRefs_MatiereRefId",
                        column: x => x.MatiereRefId,
                        principalTable: "MatiereRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentPartages_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelationCommunications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PersonneId1 = table.Column<int>(nullable: false),
                    PersonneId2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationCommunications", x => new { x.PersonneId1, x.PersonneId2 });
                    table.ForeignKey(
                        name: "FK_RelationCommunications_Personne_PersonneId1",
                        column: x => x.PersonneId1,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelationCommunications_Personne_PersonneId2",
                        column: x => x.PersonneId2,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultatUnites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoyenneUnite = table.Column<double>(nullable: true),
                    CreditUnite = table.Column<double>(nullable: true),
                    UnitePedagogiqueId = table.Column<int>(nullable: false),
                    ResultatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatUnites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultatUnites_Resultats_ResultatId",
                        column: x => x.ResultatId,
                        principalTable: "Resultats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultatUnites_UnitePedagogiques_UnitePedagogiqueId",
                        column: x => x.UnitePedagogiqueId,
                        principalTable: "UnitePedagogiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeSalle = table.Column<string>(nullable: true),
                    RefSalle = table.Column<string>(nullable: true),
                    BlocId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salles_Blocs_BlocId",
                        column: x => x.BlocId,
                        principalTable: "Blocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomaineFormations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FormationId = table.Column<int>(nullable: false),
                    DepartementId = table.Column<int>(nullable: false),
                    NomDF = table.Column<string>(nullable: true),
                    DescriptionDF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomaineFormations", x => new { x.DepartementId, x.FormationId });
                    table.ForeignKey(
                        name: "FK_DomaineFormations_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomaineFormations_Formations_FormationId",
                        column: x => x.FormationId,
                        principalTable: "Formations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: true),
                    RelationCommunicationId = table.Column<int>(nullable: false),
                    RelationCommunicationPersonneId1 = table.Column<int>(nullable: true),
                    RelationCommunicationPersonneId2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussions_RelationCommunications_RelationCommunicationPersonneId1_RelationCommunicationPersonneId2",
                        columns: x => new { x.RelationCommunicationPersonneId1, x.RelationCommunicationPersonneId2 },
                        principalTable: "RelationCommunications",
                        principalColumns: new[] { "PersonneId1", "PersonneId2" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfoSeances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    SeanceId = table.Column<int>(nullable: false),
                    SalleId = table.Column<int>(nullable: true),
                    MatiereRefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnseignatId = table.Column<int>(nullable: true),
                    MatiereRefId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSeances", x => x.MatiereRefId);
                    table.ForeignKey(
                        name: "FK_InfoSeances_Personne_EnseignatId",
                        column: x => x.EnseignatId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoSeances_MatiereRefs_MatiereRefId1",
                        column: x => x.MatiereRefId1,
                        principalTable: "MatiereRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoSeances_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filieres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomFiliere = table.Column<string>(nullable: true),
                    DescriptionFiliere = table.Column<string>(nullable: true),
                    DomaineFormationId = table.Column<int>(nullable: false),
                    DomaineFormationDepartementId = table.Column<int>(nullable: true),
                    DomaineFormationFormationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filieres_DomaineFormations_DomaineFormationDepartementId_DomaineFormationFormationId",
                        columns: x => new { x.DomaineFormationDepartementId, x.DomaineFormationFormationId },
                        principalTable: "DomaineFormations",
                        principalColumns: new[] { "DepartementId", "FormationId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    DateMsg = table.Column<DateTime>(nullable: false),
                    DiscussionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomSpecialite = table.Column<string>(nullable: true),
                    Durée = table.Column<string>(nullable: true),
                    FiliereId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialites_Filieres_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "Filieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NiveauSpecialites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Niveau = table.Column<string>(nullable: true),
                    SpecialiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveauSpecialites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NiveauSpecialites_Specialites_SpecialiteId",
                        column: x => x.SpecialiteId,
                        principalTable: "Specialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Coefficient = table.Column<double>(nullable: false),
                    Credit = table.Column<double>(nullable: false),
                    UnitePedagogiqueId = table.Column<int>(nullable: false),
                    MatiereRefId = table.Column<int>(nullable: false),
                    NiveauSpecialiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => new { x.MatiereRefId, x.NiveauSpecialiteId, x.UnitePedagogiqueId });
                    table.ForeignKey(
                        name: "FK_Matieres_MatiereRefs_MatiereRefId",
                        column: x => x.MatiereRefId,
                        principalTable: "MatiereRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matieres_NiveauSpecialites_NiveauSpecialiteId",
                        column: x => x.NiveauSpecialiteId,
                        principalTable: "NiveauSpecialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matieres_UnitePedagogiques_UnitePedagogiqueId",
                        column: x => x.UnitePedagogiqueId,
                        principalTable: "UnitePedagogiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreGroupe = table.Column<string>(nullable: true),
                    NiveauSpecialiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_NiveauSpecialites_NiveauSpecialiteId",
                        column: x => x.NiveauSpecialiteId,
                        principalTable: "NiveauSpecialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultatMatieres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoteControl = table.Column<double>(nullable: true),
                    NoteExamen = table.Column<double>(nullable: true),
                    CreditMatiere = table.Column<double>(nullable: true),
                    MatiereId = table.Column<int>(nullable: false),
                    ResultatUniteId = table.Column<int>(nullable: false),
                    MatiereRefId = table.Column<int>(nullable: true),
                    MatiereNiveauSpecialiteId = table.Column<int>(nullable: true),
                    MatiereUnitePedagogiqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatMatieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultatMatieres_ResultatUnites_ResultatUniteId",
                        column: x => x.ResultatUniteId,
                        principalTable: "ResultatUnites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultatMatieres_Matieres_MatiereRefId_MatiereNiveauSpecialiteId_MatiereUnitePedagogiqueId",
                        columns: x => new { x.MatiereRefId, x.MatiereNiveauSpecialiteId, x.MatiereUnitePedagogiqueId },
                        principalTable: "Matieres",
                        principalColumns: new[] { "MatiereRefId", "NiveauSpecialiteId", "UnitePedagogiqueId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreSGrope = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SousGroupes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousGroupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousGroupes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EtudientId = table.Column<int>(nullable: false),
                    NiveauSpecialiteId = table.Column<int>(nullable: false),
                    SousGroupeId = table.Column<int>(nullable: true),
                    ResultatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcours", x => new { x.NiveauSpecialiteId, x.EtudientId });
                    table.ForeignKey(
                        name: "FK_Parcours_Personne_EtudientId",
                        column: x => x.EtudientId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcours_NiveauSpecialites_NiveauSpecialiteId",
                        column: x => x.NiveauSpecialiteId,
                        principalTable: "NiveauSpecialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcours_Resultats_ResultatId",
                        column: x => x.ResultatId,
                        principalTable: "Resultats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcours_SousGroupes_SousGroupeId",
                        column: x => x.SousGroupeId,
                        principalTable: "SousGroupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planning",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    PlanningSectionId = table.Column<int>(nullable: true),
                    GroupeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    PlanningGroupeId = table.Column<int>(nullable: true),
                    SousGroupeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planning_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planning_Planning_PlanningSectionId",
                        column: x => x.PlanningSectionId,
                        principalTable: "Planning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planning_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planning_Planning_PlanningGroupeId",
                        column: x => x.PlanningGroupeId,
                        principalTable: "Planning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planning_SousGroupes_SousGroupeId",
                        column: x => x.SousGroupeId,
                        principalTable: "SousGroupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Journees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanningId = table.Column<int>(nullable: false),
                    Jour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journees_Planning_PlanningId",
                        column: x => x.PlanningId,
                        principalTable: "Planning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Heure = table.Column<string>(nullable: true),
                    JourneeId = table.Column<int>(nullable: false),
                    InfoSeanceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_InfoSeances_InfoSeanceId",
                        column: x => x.InfoSeanceId,
                        principalTable: "InfoSeances",
                        principalColumn: "MatiereRefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seances_Journees_JourneeId",
                        column: x => x.JourneeId,
                        principalTable: "Journees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocs_EtablissementId",
                table: "Blocs",
                column: "EtablissementId");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_EtablissementId",
                table: "Departements",
                column: "EtablissementId");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_RespCommunicationId",
                table: "Departements",
                column: "RespCommunicationId",
                unique: true,
                filter: "[RespCommunicationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_RelationCommunicationPersonneId1_RelationCommunicationPersonneId2",
                table: "Discussions",
                columns: new[] { "RelationCommunicationPersonneId1", "RelationCommunicationPersonneId2" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentPartages_MatiereRefId",
                table: "DocumentPartages",
                column: "MatiereRefId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentPartages_PersonneId",
                table: "DocumentPartages",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_DomaineFormations_FormationId",
                table: "DomaineFormations",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_Filieres_DomaineFormationDepartementId_DomaineFormationFormationId",
                table: "Filieres",
                columns: new[] { "DomaineFormationDepartementId", "DomaineFormationFormationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_SectionId",
                table: "Groupes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignatId",
                table: "InfoSeances",
                column: "EnseignatId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_MatiereRefId1",
                table: "InfoSeances",
                column: "MatiereRefId1");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_SalleId",
                table: "InfoSeances",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Journees_PlanningId",
                table: "Journees",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_NiveauSpecialiteId",
                table: "Matieres",
                column: "NiveauSpecialiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_UnitePedagogiqueId",
                table: "Matieres",
                column: "UnitePedagogiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DiscussionId",
                table: "Messages",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_NiveauSpecialites_SpecialiteId",
                table: "NiveauSpecialites",
                column: "SpecialiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcours_EtudientId",
                table: "Parcours",
                column: "EtudientId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcours_ResultatId",
                table: "Parcours",
                column: "ResultatId",
                unique: true,
                filter: "[ResultatId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parcours_SousGroupeId",
                table: "Parcours",
                column: "SousGroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_GroupeId",
                table: "Planning",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_PlanningSectionId",
                table: "Planning",
                column: "PlanningSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_SectionId",
                table: "Planning",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_PlanningGroupeId",
                table: "Planning",
                column: "PlanningGroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_SousGroupeId",
                table: "Planning",
                column: "SousGroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationCommunications_PersonneId2",
                table: "RelationCommunications",
                column: "PersonneId2");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatMatieres_ResultatUniteId",
                table: "ResultatMatieres",
                column: "ResultatUniteId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatMatieres_MatiereRefId_MatiereNiveauSpecialiteId_MatiereUnitePedagogiqueId",
                table: "ResultatMatieres",
                columns: new[] { "MatiereRefId", "MatiereNiveauSpecialiteId", "MatiereUnitePedagogiqueId" });

            migrationBuilder.CreateIndex(
                name: "IX_ResultatUnites_ResultatId",
                table: "ResultatUnites",
                column: "ResultatId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatUnites_UnitePedagogiqueId",
                table: "ResultatUnites",
                column: "UnitePedagogiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Salles_BlocId",
                table: "Salles",
                column: "BlocId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_InfoSeanceId",
                table: "Seances",
                column: "InfoSeanceId",
                unique: true,
                filter: "[InfoSeanceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_JourneeId",
                table: "Seances",
                column: "JourneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_NiveauSpecialiteId",
                table: "Sections",
                column: "NiveauSpecialiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SousGroupes_GroupeId",
                table: "SousGroupes",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialites_FiliereId",
                table: "Specialites",
                column: "FiliereId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentPartages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Parcours");

            migrationBuilder.DropTable(
                name: "ResultatMatieres");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "ResultatUnites");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "InfoSeances");

            migrationBuilder.DropTable(
                name: "Journees");

            migrationBuilder.DropTable(
                name: "RelationCommunications");

            migrationBuilder.DropTable(
                name: "Resultats");

            migrationBuilder.DropTable(
                name: "UnitePedagogiques");

            migrationBuilder.DropTable(
                name: "MatiereRefs");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Planning");

            migrationBuilder.DropTable(
                name: "Blocs");

            migrationBuilder.DropTable(
                name: "SousGroupes");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "NiveauSpecialites");

            migrationBuilder.DropTable(
                name: "Specialites");

            migrationBuilder.DropTable(
                name: "Filieres");

            migrationBuilder.DropTable(
                name: "DomaineFormations");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "Etablissements");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
