﻿namespace Blood_donate_App_Backend.Models.DTOs
{
    public class EnumClass
    {
        public enum FulFillmentStatus
        {
            Fulfilled,
            NotFulfilled,
            PartiallyFulfilled
        }

        public enum Urgency
        {
            Immediate,
            WithinAWeek,
        }

        public enum Roles
        {
            Member,
            Admin,
            CenterAdmin
        }

        public enum RequestApprovalStatus
        {
            Approved,
            Pending,
            Rejected
        }

        public enum DonationStatus
        {
            NotDonated,
            Donated,
            Rejected,   
        }

        public enum DonationType
        {
            Requester,
            Center
        }

        public enum BloodType
        {
            A,
            B,
            AB,
            O
        }

        public enum RhFactor
        { 
            positive,
            negative
        }

    }
}
