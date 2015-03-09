﻿using System;
using System.Linq;

using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    public class EFMainRepository : IMainRepository
    {
        private MainDbContext context;

        public EFMainRepository()
        {
            this.context = new MainDbContext();
        }

        public IQueryable<Auction> GetAuctions()
        {
            return this.context.Auctions;
        }

        public IQueryable<Member> GetMembers()
        {
            return this.context.Members;
        }

        public Bid GetBidByTransactionId(Guid transactionId)
        {
            return this.context.Bids.FirstOrDefault(b => b.TransactionId == transactionId);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public Member Add(Member member)
        {
            this.context.Members.Add(member);

            return member;
        }

        public Bid Add(Bid bid)
        {
            this.context.Bids.Add(bid);

            return bid;
        }

        public Auction Update(Auction auction)
        {
            return auction;
        }

        public Auction Add(Auction auction)
        {
            this.context.Auctions.Add(auction);

            return auction;
        }
    }
}
