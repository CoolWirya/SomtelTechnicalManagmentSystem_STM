using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SomtelTechnicalManagmentSystem_STM.Models.ActiveXpertModel;

#nullable disable

namespace SomtelTechnicalManagmentSystem_STM.Data
{
    public partial class ActiveXpertDbContext : DbContext
    {
        public ActiveXpertDbContext()
        {
        }

        public ActiveXpertDbContext(DbContextOptions<ActiveXpertDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InsertSm> InsertSms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:SMSC");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsertSm>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InsertSms");

                entity.Property(e => e.AckStatusId)
                    .HasMaxLength(32)
                    .HasColumnName("AckStatusID");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.BillingId)
                    .HasMaxLength(255)
                    .HasColumnName("BillingID");

                entity.Property(e => e.ChannelId)
                    .HasMaxLength(32)
                    .HasColumnName("ChannelID");

                entity.Property(e => e.ConversationId).HasColumnName("ConversationID");

                entity.Property(e => e.Creator).HasMaxLength(32);

                entity.Property(e => e.CustomField2).HasMaxLength(255);

                entity.Property(e => e.DeliveryStatus).HasMaxLength(32);

                entity.Property(e => e.DirectionId)
                    .HasMaxLength(32)
                    .HasColumnName("DirectionID");

                entity.Property(e => e.FromAddress).HasMaxLength(32);

                entity.Property(e => e.GsmSmscAddress).HasMaxLength(32);

                entity.Property(e => e.Hash).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.SmppClient).HasMaxLength(64);

                entity.Property(e => e.SmppServiceType).HasMaxLength(32);

                entity.Property(e => e.StatusDetailsId).HasColumnName("StatusDetailsID");

                entity.Property(e => e.StatusId)
                    .HasMaxLength(32)
                    .HasColumnName("StatusID");

                entity.Property(e => e.ToAddress).HasMaxLength(32);

                entity.Property(e => e.Trace).IsRequired();

                entity.Property(e => e.TriggerDetailsId).HasColumnName("TriggerDetailsID");

                entity.Property(e => e.TriggerStatusId)
                    .HasMaxLength(32)
                    .HasColumnName("TriggerStatusID");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(32)
                    .HasColumnName("TypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
