namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "event",
                c => new
                    {
                        idEvent = c.Int(nullable: false, identity: true),
                        dateDebut = c.DateTime(precision: 0),
                        dateFin = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, unicode: false),
                        nomEvent = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idEvent);
            
            CreateTable(
                "candidate",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        codePostal = c.String(maxLength: 255, unicode: false),
                        pays = c.String(maxLength: 255, unicode: false),
                        rue = c.String(maxLength: 255, unicode: false),
                        ville = c.String(maxLength: 255, unicode: false),
                        classType = c.String(maxLength: 255, unicode: false),
                        dateNaissance = c.DateTime(storeType: "date"),
                        email = c.String(maxLength: 255, unicode: false),
                        image = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                        cv = c.String(maxLength: 255, unicode: false),
                        etat = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "passage",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        candidateId = c.Int(nullable: false),
                        answer1 = c.Boolean(storeType: "bit"),
                        answer10 = c.Boolean(storeType: "bit"),
                        answer2 = c.Boolean(storeType: "bit"),
                        answer3 = c.Boolean(storeType: "bit"),
                        answer4 = c.Boolean(storeType: "bit"),
                        answer5 = c.Boolean(storeType: "bit"),
                        answer6 = c.Boolean(storeType: "bit"),
                        answer7 = c.Boolean(storeType: "bit"),
                        answer8 = c.Boolean(storeType: "bit"),
                        answer9 = c.Boolean(storeType: "bit"),
                        dateOfPassing = c.DateTime(precision: 0),
                        mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestId, t.candidateId })
                .ForeignKey("test", t => t.TestId)
                .ForeignKey("candidate", t => t.candidateId)
                .Index(t => t.TestId)
                .Index(t => t.candidateId);
            
            CreateTable(
                "test",
                c => new
                    {
                        testId = c.Int(nullable: false, identity: true),
                        answer1 = c.Boolean(storeType: "bit"),
                        answer10 = c.Boolean(storeType: "bit"),
                        answer2 = c.Boolean(storeType: "bit"),
                        answer3 = c.Boolean(storeType: "bit"),
                        answer4 = c.Boolean(storeType: "bit"),
                        answer5 = c.Boolean(storeType: "bit"),
                        answer6 = c.Boolean(storeType: "bit"),
                        answer7 = c.Boolean(storeType: "bit"),
                        answer8 = c.Boolean(storeType: "bit"),
                        answer9 = c.Boolean(storeType: "bit"),
                        q1 = c.String(maxLength: 255, unicode: false),
                        q10 = c.String(maxLength: 255, unicode: false),
                        q2 = c.String(maxLength: 255, unicode: false),
                        q3 = c.String(maxLength: 255, unicode: false),
                        q4 = c.String(maxLength: 255, unicode: false),
                        q5 = c.String(maxLength: 255, unicode: false),
                        q6 = c.String(maxLength: 255, unicode: false),
                        q7 = c.String(maxLength: 255, unicode: false),
                        q8 = c.String(maxLength: 255, unicode: false),
                        q9 = c.String(maxLength: 255, unicode: false),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.testId);
            
            CreateTable(
                "client",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        codePostal = c.String(maxLength: 255, unicode: false),
                        pays = c.String(maxLength: 255, unicode: false),
                        rue = c.String(maxLength: 255, unicode: false),
                        ville = c.String(maxLength: 255, unicode: false),
                        classType = c.String(maxLength: 255, unicode: false),
                        dateNaissance = c.DateTime(storeType: "date"),
                        email = c.String(maxLength: 255, unicode: false),
                        image = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                        clientCategory = c.String(maxLength: 255, unicode: false),
                        clientType = c.String(maxLength: 255, unicode: false),
                        latitude = c.Double(),
                        longitude = c.Double(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "project",
                c => new
                    {
                        projectId = c.Int(nullable: false, identity: true),
                        ProjectType = c.String(maxLength: 255, unicode: false),
                        codePostal = c.String(maxLength: 255, unicode: false),
                        pays = c.String(maxLength: 255, unicode: false),
                        rue = c.String(maxLength: 255, unicode: false),
                        ville = c.String(maxLength: 255, unicode: false),
                        competence = c.String(maxLength: 255, unicode: false),
                        dateDebut = c.DateTime(precision: 0),
                        dateFin = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, unicode: false),
                        nbrResource = c.Int(nullable: false),
                        photo = c.String(maxLength: 255, unicode: false),
                        projectName = c.String(maxLength: 255, unicode: false),
                        client = c.Int(),
                    })
                .PrimaryKey(t => t.projectId)
                .ForeignKey("client", t => t.client)
                .Index(t => t.client);
            
            CreateTable(
                "mandate",
                c => new
                    {
                        projectId = c.Int(nullable: false),
                        resourceId = c.Int(nullable: false),
                        debutMandat = c.DateTime(precision: 0),
                        finMandat = c.DateTime(precision: 0),
                        archive = c.Boolean(nullable: false, storeType: "bit"),
                        isValid = c.Boolean(nullable: false, storeType: "bit"),
                    })
                .PrimaryKey(t => new { t.projectId, t.resourceId })
                .ForeignKey("resource", t => t.resourceId)
                .ForeignKey("project", t => t.projectId)
                .Index(t => t.projectId)
                .Index(t => t.resourceId);
            
            CreateTable(
                "resource",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        codePostal = c.String(maxLength: 255, unicode: false),
                        pays = c.String(maxLength: 255, unicode: false),
                        rue = c.String(maxLength: 255, unicode: false),
                        ville = c.String(maxLength: 255, unicode: false),
                        classType = c.String(maxLength: 255, unicode: false),
                        dateNaissance = c.DateTime(storeType: "date"),
                        email = c.String(maxLength: 255, unicode: false),
                        image = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                        accepted = c.Boolean(nullable: false, storeType: "bit"),
                        archivé = c.Boolean(nullable: false, storeType: "bit"),
                        competance = c.String(maxLength: 255, unicode: false),
                        cv = c.String(maxLength: 255, unicode: false),
                        note = c.Single(nullable: false),
                        resourceState = c.String(maxLength: 255, unicode: false),
                        resourceType = c.String(maxLength: 255, unicode: false),
                        seniority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "conge",
                c => new
                    {
                        idConge = c.Int(nullable: false, identity: true),
                        congeDebut = c.DateTime(precision: 0),
                        congeFin = c.DateTime(precision: 0),
                        resourceId = c.Int(),
                        accepter = c.Boolean(nullable: false, storeType: "bit"),
                    })
                .PrimaryKey(t => t.idConge)
                .ForeignKey("resource", t => t.resourceId)
                .Index(t => t.resourceId);
            
            CreateTable(
                "demande",
                c => new
                    {
                        idDemande = c.Int(nullable: false, identity: true),
                        TestInteger = c.String(maxLength: 255, unicode: false),
                        TestString = c.String(maxLength: 255, unicode: false),
                        anneeExp = c.Int(),
                        bac = c.String(maxLength: 255, unicode: false),
                        competance = c.String(maxLength: 255, unicode: false),
                        cout = c.Single(nullable: false),
                        dateDebutMandat = c.String(maxLength: 255, unicode: false),
                        dateDepot = c.String(maxLength: 255, unicode: false),
                        dateFinMandat = c.String(maxLength: 255, unicode: false),
                        description = c.String(maxLength: 255, unicode: false),
                        diplome = c.String(maxLength: 255, unicode: false),
                        directeur = c.String(maxLength: 255, unicode: false),
                        duree = c.Int(),
                        heureDepot = c.String(maxLength: 255, unicode: false),
                        nomProjet = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idDemande);
            
            CreateTable(
                "message",
                c => new
                    {
                        idMessage = c.Int(nullable: false, identity: true),
                        body = c.String(maxLength: 255, unicode: false),
                        dateEnvoi = c.String(maxLength: 255, unicode: false),
                        isArchive = c.Int(),
                        lu = c.Int(),
                        messageCible = c.String(maxLength: 255, unicode: false),
                        messageType = c.String(maxLength: 255, unicode: false),
                        receiver = c.Int(),
                        sender = c.Int(),
                    })
                .PrimaryKey(t => t.idMessage);
            
            CreateTable(
                "user_message",
                c => new
                    {
                        User_userId = c.Int(nullable: false),
                        listeMessagesended_idMessage = c.Int(nullable: false),
                        listeMessagereceived_idMessage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_userId, t.listeMessagesended_idMessage, t.listeMessagereceived_idMessage })
                .ForeignKey("message", t => t.listeMessagesended_idMessage)
                .ForeignKey("message", t => t.listeMessagereceived_idMessage)
                .Index(t => t.listeMessagesended_idMessage)
                .Index(t => t.listeMessagereceived_idMessage);
            
            CreateTable(
                "rendvous",
                c => new
                    {
                        rdId = c.Int(nullable: false),
                        ClientNom = c.String(maxLength: 255, unicode: false),
                        arch = c.Boolean(nullable: false, storeType: "bit"),
                        dateInsert = c.DateTime(storeType: "date"),
                        dateRdv = c.DateTime(storeType: "date"),
                        description = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        etat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.rdId);
            
            CreateTable(
                "user",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        codePostal = c.String(maxLength: 255, unicode: false),
                        pays = c.String(maxLength: 255, unicode: false),
                        rue = c.String(maxLength: 255, unicode: false),
                        ville = c.String(maxLength: 255, unicode: false),
                        classType = c.String(maxLength: 255, unicode: false),
                        dateNaissance = c.DateTime(storeType: "date"),
                        email = c.String(maxLength: 255, unicode: false),
                        image = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.test_passage",
                c => new
                    {
                        Test_testId = c.Int(nullable: false),
                        listePassage_TestId = c.Int(nullable: false),
                        listePassage_candidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_testId, t.listePassage_TestId, t.listePassage_candidateId })
                .ForeignKey("test", t => t.Test_testId, cascadeDelete: true)
                .ForeignKey("passage", t => new { t.listePassage_TestId, t.listePassage_candidateId }, cascadeDelete: true)
                .Index(t => t.Test_testId)
                .Index(t => new { t.listePassage_TestId, t.listePassage_candidateId });
            
            CreateTable(
                "candidate_passage",
                c => new
                    {
                        Candidate_userId = c.Int(nullable: false),
                        listePassage_TestId = c.Int(nullable: false),
                        listePassage_candidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Candidate_userId, t.listePassage_TestId, t.listePassage_candidateId })
                .ForeignKey("candidate", t => t.Candidate_userId, cascadeDelete: true)
                .ForeignKey("passage", t => new { t.listePassage_TestId, t.listePassage_candidateId }, cascadeDelete: true)
                .Index(t => t.Candidate_userId)
                .Index(t => new { t.listePassage_TestId, t.listePassage_candidateId });
            
            CreateTable(
                "resource_conge",
                c => new
                    {
                        listeConge_idConge = c.Int(nullable: false),
                        Resource_userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.listeConge_idConge, t.Resource_userId })
                .ForeignKey("conge", t => t.listeConge_idConge, cascadeDelete: true)
                .ForeignKey("resource", t => t.Resource_userId, cascadeDelete: true)
                .Index(t => t.listeConge_idConge)
                .Index(t => t.Resource_userId);
            
            CreateTable(
                "resource_mandate",
                c => new
                    {
                        listeMandate_projectId = c.Int(nullable: false),
                        listeMandate_resourceId = c.Int(nullable: false),
                        Resource_userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.listeMandate_projectId, t.listeMandate_resourceId, t.Resource_userId })
                .ForeignKey("mandate", t => new { t.listeMandate_projectId, t.listeMandate_resourceId }, cascadeDelete: true)
                .ForeignKey("resource", t => t.Resource_userId, cascadeDelete: true)
                .Index(t => new { t.listeMandate_projectId, t.listeMandate_resourceId })
                .Index(t => t.Resource_userId);
            
            CreateTable(
                "project_mandate",
                c => new
                    {
                        Project_projectId = c.Int(nullable: false),
                        listeMandate_projectId = c.Int(nullable: false),
                        listeMandate_resourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_projectId, t.listeMandate_projectId, t.listeMandate_resourceId })
                .ForeignKey("project", t => t.Project_projectId, cascadeDelete: true)
                .ForeignKey("mandate", t => new { t.listeMandate_projectId, t.listeMandate_resourceId }, cascadeDelete: true)
                .Index(t => t.Project_projectId)
                .Index(t => new { t.listeMandate_projectId, t.listeMandate_resourceId });
            
            CreateTable(
                "dbo.client_project",
                c => new
                    {
                        Client_userId = c.Int(nullable: false),
                        listeProject_projectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_userId, t.listeProject_projectId })
                .ForeignKey("client", t => t.Client_userId, cascadeDelete: true)
                .ForeignKey("project", t => t.listeProject_projectId, cascadeDelete: true)
                .Index(t => t.Client_userId)
                .Index(t => t.listeProject_projectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("user_message", "listeMessagereceived_idMessage", "message");
            DropForeignKey("user_message", "listeMessagesended_idMessage", "message");
            DropForeignKey("dbo.client_project", "listeProject_projectId", "project");
            DropForeignKey("dbo.client_project", "Client_userId", "client");
            DropForeignKey("project", "client", "client");
            DropForeignKey("dbo.project_mandate", new[] { "listeMandate_projectId", "listeMandate_resourceId" }, "mandate");
            DropForeignKey("dbo.project_mandate", "Project_projectId", "project");
            DropForeignKey("mandate", "projectId", "project");
            DropForeignKey("dbo.resource_mandate", "Resource_userId", "resource");
            DropForeignKey("dbo.resource_mandate", new[] { "listeMandate_projectId", "listeMandate_resourceId" }, ".mandate");
            DropForeignKey("mandate", "resourceId", "resource");
            DropForeignKey("conge", "resourceId", "resource");
            DropForeignKey("dbo.resource_conge", "Resource_userId", "map_ds.resource");
            DropForeignKey("dbo.resource_conge", "listeConge_idConge", "map_ds.conge");
            DropForeignKey("dbo.candidate_passage", new[] { "listePassage_TestId", "listePassage_candidateId" }, "passage");
            DropForeignKey("dbo.candidate_passage", "Candidate_userId", "candidate");
            DropForeignKey("passage", "candidateId", "candidate");
            DropForeignKey("dbo.test_passage", new[] { "listePassage_TestId", "listePassage_candidateId" }, "passage");
            DropForeignKey("dbo.test_passage", "Test_testId", "test");
            DropForeignKey("passage", "TestId", "test");
            DropIndex("dbo.client_project", new[] { "listeProject_projectId" });
            DropIndex("dbo.client_project", new[] { "Client_userId" });
            DropIndex("dbo.project_mandate", new[] { "listeMandate_projectId", "listeMandate_resourceId" });
            DropIndex("dbo.project_mandate", new[] { "Project_projectId" });
            DropIndex("dbo.resource_mandate", new[] { "Resource_userId" });
            DropIndex("dbo.resource_mandate", new[] { "listeMandate_projectId", "listeMandate_resourceId" });
            DropIndex("dbo.resource_conge", new[] { "Resource_userId" });
            DropIndex("dbo.resource_conge", new[] { "listeConge_idConge" });
            DropIndex("dbo.candidate_passage", new[] { "listePassage_TestId", "listePassage_candidateId" });
            DropIndex("dbo.candidate_passage", new[] { "Candidate_userId" });
            DropIndex("dbo.test_passage", new[] { "listePassage_TestId", "listePassage_candidateId" });
            DropIndex("dbo.test_passage", new[] { "Test_testId" });
            DropIndex("user_message", new[] { "listeMessagereceived_idMessage" });
            DropIndex("user_message", new[] { "listeMessagesended_idMessage" });
            DropIndex("conge", new[] { "resourceId" });
            DropIndex("mandate", new[] { "resourceId" });
            DropIndex("mandate", new[] { "projectId" });
            DropIndex("project", new[] { "client" });
            DropIndex("passage", new[] { "candidateId" });
            DropIndex("passage", new[] { "TestId" });
            DropTable("dbo.client_project");
            DropTable("dbo.project_mandate");
            DropTable("dbo.resource_mandate");
            DropTable("dbo.resource_conge");
            DropTable("dbo.candidate_passage");
            DropTable("dbo.test_passage");
            DropTable("user");
            DropTable("rendvous");
            DropTable("user_message");
            DropTable("message");
            DropTable("demande");
            DropTable("conge");
            DropTable("resource");
            DropTable("mandate");
            DropTable("project");
            DropTable("client");
            DropTable("test");
            DropTable("passage");
            DropTable("candidate");
            DropTable("event");
        }
    }
}
