namespace Juice_Demo_Modulr.Core.Common.Enums
{
    public enum VerificationStatus
    {
        UNVERIFIED = 0, //no verification checks have been completed
        VERIFIED, // verification checks completed satisfactorily
        EXVERIFIED, //verification completed externally
        REFERRED, //verification is pending manual review
        DECLINED, //verification is complete with a negative result
        REVIEWED //verification check has been reviewed
    }
}
