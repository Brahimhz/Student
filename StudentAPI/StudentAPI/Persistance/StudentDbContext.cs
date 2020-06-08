using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.Models;

namespace StudentAPI.Persistance
{
    public class StudentDbContext : DbContext
    {


        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Filiere>()
            .HasOne<DomaineFormation>(f => f.DomaineFormation)
            .WithMany(df => df.Filieres)
            .HasForeignKey(f => f.DomaineFormationId);

            modelBuilder.Entity<DomaineFormation>()
                .HasKey(df => df.Id);
            modelBuilder.Entity<DomaineFormation>()
                  .Property(p => p.Id)
                  .ValueGeneratedOnAdd();

            modelBuilder.Entity<RelationCommunication>()
             .HasKey(rc => new { rc.PersonneId1, rc.PersonneId2 });


            modelBuilder.Entity<InfoSeance>()
                    .HasKey(i => new { i.MatiereRefId });

            modelBuilder.Entity<InfoSeance>()
                .HasOne(i => i.Seance)
                .WithOne(s => s.InfoSeances)
                .HasForeignKey<Seance>(s => s.InfoSeanceId);


            modelBuilder.Entity<Matiere>()
             .HasKey(m => new { m.MatiereRefId, m.NiveauSpecialiteId, m.UnitePedagogiqueId });


            modelBuilder.Entity<Parcour>()
             .HasKey(p => new { p.NiveauSpecialiteId, p.EtudientId });

            modelBuilder.Entity<Personne>()
                .HasMany(p => p.RelationCommunications1)
                .WithOne(rc => rc.Personne1)
                .HasForeignKey(rc => rc.PersonneId1);

            modelBuilder.Entity<Personne>()
                .HasMany(p => p.RelationCommunications2)
                .WithOne(rc => rc.Personne2)
                .HasForeignKey(rc => rc.PersonneId2);



            modelBuilder.Entity<RespCommunication>()
                .HasOne(rsp => rsp.Departement)
                .WithOne(d => d.RespCommunication)
                .HasForeignKey<Departement>(d => d.RespCommunicationId);


            modelBuilder.Entity<PlanningSection>()
               .HasOne(ps => ps.Section)
               .WithMany(s => s.PlanningSections)
               .IsRequired()
               .HasForeignKey(ps => ps.SectionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlanningGroupe>()
               .HasOne(pg => pg.Groupe)
               .WithMany(g => g.PlanningGroupes)
               .IsRequired()
               .HasForeignKey(pg => pg.GroupeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlanningSGroupe>()
               .HasOne(psg => psg.SousGroupe)
               .WithMany(sg => sg.PlanningSGroupes)
               .IsRequired()
               .HasForeignKey(psg => psg.SousGroupeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RelationCommunication>()
              .HasOne(rc => rc.Personne1)
              .WithMany(p => p.RelationCommunications1)
              .IsRequired()
              .HasForeignKey(rc => rc.PersonneId1)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RelationCommunication>()
              .HasOne(rc => rc.Personne2)
              .WithMany(p => p.RelationCommunications2)
              .IsRequired()
              .HasForeignKey(rc => rc.PersonneId2)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PlanningGroupe>()
              .HasOne(pg => pg.PlanningSection)
              .WithMany(ps => ps.PlanningGroupes)
              .IsRequired()
              .HasForeignKey(pg => pg.PlanningSectionId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlanningSGroupe>()
              .HasOne(psg => psg.PlanningGroupe)
              .WithMany(pg => pg.PlanningSGroupes)
              .IsRequired()
              .HasForeignKey(psg => psg.PlanningGroupeId)
              .OnDelete(DeleteBehavior.Restrict);




        }

        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Journee> Journees { get; set; }
        public virtual DbSet<DomaineFormation> DomaineFormations { get; set; }

        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<InfoSeance> InfoSeances { get; set; }
        public virtual DbSet<Bloc> Blocs { get; set; }
        public virtual DbSet<Salle> Salles { get; set; }
        public virtual DbSet<Etablissement> Etablissements { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Filiere> Filieres { get; set; }
        public virtual DbSet<Specialite> Specialites { get; set; }
        public virtual DbSet<NiveauSpecialite> NiveauSpecialites { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<SousGroupe> SousGroupes { get; set; }
        public virtual DbSet<Matiere> Matieres { get; set; }
        public virtual DbSet<UnitePedagogique> UnitePedagogiques { get; set; }
        public virtual DbSet<MatiereRef> MatiereRefs { get; set; }
        public virtual DbSet<Parcour> Parcours { get; set; }
        public virtual DbSet<Resultat> Resultats { get; set; }
        public virtual DbSet<ResultatUnite> ResultatUnites { get; set; }
        public virtual DbSet<ResultatMatiere> ResultatMatieres { get; set; }
        public virtual DbSet<RelationCommunication> RelationCommunications { get; set; }
        public virtual DbSet<Discussion> Discussions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<DocumentPartage> DocumentPartages { get; set; }

        public virtual DbSet<Etudiant> Etudiants { get; set; }
        public virtual DbSet<Enseignant> Enseignats { get; set; }
        public virtual DbSet<RespCommunication> RespCommunications { get; set; }
        public virtual DbSet<PlanningSection> PlanningSections { get; set; }
        public virtual DbSet<PlanningGroupe> PlanningGroupes { get; set; }
        public virtual DbSet<PlanningSGroupe> PlanningSGroupes { get; set; }

    }
}
