namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domaine;

    public partial class mapContext : DbContext
    {
        public mapContext()
            : base("name=map_ds")
        {
        }

        public virtual DbSet<candidate> candidate { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<conge> conge { get; set; }
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<_event> _event { get; set; }
        public virtual DbSet<mandate> mandate { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<passage> passage { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<rendvous> rendvous { get; set; }
        public virtual DbSet<resource> resource { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_message> user_message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<candidate>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.pays)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.classType)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<candidate>()
                .HasMany(e => e.passage)
                .WithRequired(e => e.candidate)
                .HasForeignKey(e => e.candidateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<candidate>()
                .HasMany(e => e.passage1)
                .WithMany(e => e.candidate1)
                .Map(m => m.ToTable("candidate_passage").MapLeftKey("Candidate_userId").MapRightKey(new[] { "listePassage_TestId", "listePassage_candidateId" }));

            modelBuilder.Entity<client>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.pays)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.classType)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.clientCategory)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.clientType)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.project)
                .WithOptional(e => e.client1)
                .HasForeignKey(e => e.client);

            modelBuilder.Entity<client>()
                .HasMany(e => e.project1)
                .WithMany(e => e.client2)
                .Map(m => m.ToTable("client_project").MapLeftKey("Client_userId").MapRightKey("listeProject_projectId"));

            modelBuilder.Entity<conge>()
                .HasMany(e => e.resource1)
                .WithMany(e => e.conge1)
                .Map(m => m.ToTable("resource_conge").MapLeftKey("listeConge_idConge").MapRightKey("Resource_userId"));

            modelBuilder.Entity<demande>()
                .Property(e => e.TestInteger)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.TestString)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.bac)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.competance)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.dateDebutMandat)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.dateDepot)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.dateFinMandat)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.diplome)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.directeur)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.heureDepot)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.nomProjet)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.nomEvent)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .HasMany(e => e.resource1)
                .WithMany(e => e.mandate1)
                .Map(m => m.ToTable("resource_mandate").MapLeftKey(new[] { "listeMandate_projectId", "listeMandate_resourceId" }).MapRightKey("Resource_userId"));

            modelBuilder.Entity<message>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.dateEnvoi)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.messageCible)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.messageType)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .HasMany(e => e.user_message)
                .WithRequired(e => e.message)
                .HasForeignKey(e => e.listeMessagesended_idMessage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<message>()
                .HasMany(e => e.user_message1)
                .WithRequired(e => e.message1)
                .HasForeignKey(e => e.listeMessagereceived_idMessage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<project>()
                .Property(e => e.ProjectType)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.pays)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.competence)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.projectName)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.mandate)
                .WithRequired(e => e.project)
                .HasForeignKey(e => e.projectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.mandate1)
                .WithMany(e => e.project1)
                .Map(m => m.ToTable("project_mandate").MapLeftKey("Project_projectId").MapRightKey(new[] { "listeMandate_projectId", "listeMandate_resourceId" }));

            modelBuilder.Entity<rendvous>()
                .Property(e => e.ClientNom)
                .IsUnicode(false);

            modelBuilder.Entity<rendvous>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<rendvous>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.pays)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.classType)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.competance)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.resourceState)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.resourceType)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.conge)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.resourceId);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.mandate)
                .WithRequired(e => e.resource)
                .HasForeignKey(e => e.resourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q1)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q10)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q2)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q3)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q4)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q5)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q6)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q7)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q8)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.q9)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.passage)
                .WithRequired(e => e.test)
                .HasForeignKey(e => e.TestId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.passage1)
                .WithMany(e => e.test1)
                .Map(m => m.ToTable("test_passage").MapLeftKey("Test_testId").MapRightKey(new[] { "listePassage_TestId", "listePassage_candidateId" }));

            modelBuilder.Entity<user>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.pays)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.classType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
