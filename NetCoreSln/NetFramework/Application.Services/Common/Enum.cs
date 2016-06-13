namespace Application.Services.Common
{
    public enum EnumsRecordStatus
    {
        正常, 废弃,启用,停用
    }

    public enum EnumsNoticePublishStatus
    {
        保存, 发布
    }


    public enum EnumsAgreementSignStatus
    {
        同意, 不同意,未确认
    }

    /// <summary>
    /// 上传状态  
    /// </summary>
    public enum EFileUploadStatus
    {
        上传,
        关联,
        废弃,
        未完成,
        已提交 
    }


    public enum EFileUploadClient
    { 
        NoticeAffix,
        HomeWorkAffix,
        CourseAffix,
        TrainingWorkAffix,
        TrainingWorkSubmitAffix 
    }
}
