using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExpertCompetence.Models
{
    public partial class ExpertCompetenceContext : DbContext
    {
        public ExpertCompetenceContext()
        {
        }

        public ExpertCompetenceContext(DbContextOptions<ExpertCompetenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudioGuide> AudioGuide { get; set; }
        public virtual DbSet<AudioGuideRate> AudioGuideRate { get; set; }
        public virtual DbSet<Competence> Competence { get; set; }
        public virtual DbSet<CompetenceAudioGuide> CompetenceAudioGuide { get; set; }
        public virtual DbSet<CompetenceLevel> CompetenceLevel { get; set; }
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<Meditation> Meditation { get; set; }
        public virtual DbSet<Mentoring> Mentoring { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserFeature> UserFeature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NST5P2P;Initial Catalog=ExpertCompetence;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioGuide>(entity =>
            {
                entity.ToTable("audio_guide");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExpertId).HasColumnName("expert_id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.AudioGuide)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK__audio_gui__exper__440B1D61");
            });

            modelBuilder.Entity<AudioGuideRate>(entity =>
            {
                entity.ToTable("audio_guide_rate");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AudioGuideId).HasColumnName("audio_guide_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AudioGuide)
                    .WithMany(p => p.AudioGuideRate)
                    .HasForeignKey(d => d.AudioGuideId)
                    .HasConstraintName("FK__audio_gui__audio__3C69FB99");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AudioGuideRate)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__audio_gui__user___3D5E1FD2");
            });

            modelBuilder.Entity<Competence>(entity =>
            {
                entity.ToTable("competence");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AudioGuideId).HasColumnName("audio_guide_id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CompetenceAudioGuide>(entity =>
            {
                entity.ToTable("competence_audio_guide");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AudioGuideId).HasColumnName("audio_guide_id");

                entity.Property(e => e.CompetenceId).HasColumnName("competence_id");

                entity.HasOne(d => d.AudioGuide)
                    .WithMany(p => p.CompetenceAudioGuide)
                    .HasForeignKey(d => d.AudioGuideId)
                    .HasConstraintName("FK__competenc__audio__412EB0B6");

                entity.HasOne(d => d.Competence)
                    .WithMany(p => p.CompetenceAudioGuide)
                    .HasForeignKey(d => d.CompetenceId)
                    .HasConstraintName("FK__competenc__compe__44FF419A");
            });

            modelBuilder.Entity<CompetenceLevel>(entity =>
            {
                entity.ToTable("competence_level");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompetenceId).HasColumnName("competence_id");

                entity.Property(e => e.ExpertId).HasColumnName("expert_id");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.HasOne(d => d.Competence)
                    .WithMany(p => p.CompetenceLevel)
                    .HasForeignKey(d => d.CompetenceId)
                    .HasConstraintName("FK__competenc__compe__3F466844");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CompetenceLevel)
                    .HasForeignKey<CompetenceLevel>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__competence_l__id__4222D4EF");
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.ToTable("expert");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Meditation>(entity =>
            {
                entity.ToTable("meditation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AudioGuideId).HasColumnName("audio_guide_id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.NeuralNetworkScore).HasColumnName("neural_network_score");

                entity.Property(e => e.PhysiologyScore).HasColumnName("physiology_score");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WearbleDiviceScore).HasColumnName("wearble_divice_score");

                entity.HasOne(d => d.AudioGuide)
                    .WithMany(p => p.Meditation)
                    .HasForeignKey(d => d.AudioGuideId)
                    .HasConstraintName("FK__meditatio__audio__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meditation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__meditatio__user___398D8EEE");
            });

            modelBuilder.Entity<Mentoring>(entity =>
            {
                entity.ToTable("mentoring");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExpertId).HasColumnName("expert_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.Mentoring)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK__mentoring__exper__37A5467C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mentoring)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__mentoring__user___38996AB5");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpertId).HasColumnName("expert_id");

                entity.Property(e => e.MeditationId).HasColumnName("meditation_id");

                entity.Property(e => e.ReviewText)
                    .HasColumnName("review_text")
                    .HasMaxLength(255);

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK__review__expert_i__3B75D760");

                entity.HasOne(d => d.Meditation)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.MeditationId)
                    .HasConstraintName("FK__review__meditati__3A81B327");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(255);

                entity.Property(e => e.MeditationAim)
                    .HasColumnName("meditation_aim")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserFeature>(entity =>
            {
                entity.ToTable("user_feature");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompetenceId).HasColumnName("competence_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Competence)
                    .WithMany(p => p.UserFeature)
                    .HasForeignKey(d => d.CompetenceId)
                    .HasConstraintName("FK__user_feat__compe__3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFeature)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__user_feat__user___403A8C7D");
            });

          
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
