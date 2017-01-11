using SurferTech.OA.DataModel.Enums;
using SurferTech.OA.ServiceContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurferTech.OA.Web.Models
{
    public class ProjectViewModel
    {
        public ProjectModel Project { get; private set; }

        public string StatusDescription { get; private set; }

        public string StatusClass { get; private set; }

        public ProjectViewModel(ProjectModel p)
        {
            this.Project = p;
            switch ((ProjectStatus)p.Status)
            {
                case ProjectStatus.ToBeActivated:
                    StatusDescription = "待启动";
                    StatusClass = "text-warning";
                    break;
                case ProjectStatus.Activated:
                    StatusDescription = "已启动";
                    StatusClass = "text-info";
                    break;
                case ProjectStatus.Working:
                    StatusDescription = "施工中";
                    StatusClass = "text-info";
                    break;
                case ProjectStatus.Reworking:
                    StatusDescription = "返工中";
                    StatusClass = "text-danger";
                    break;
                case ProjectStatus.Approved:
                    StatusDescription = "已验收";
                    StatusClass = "text-success";
                    break;
            }
        }
    }
}