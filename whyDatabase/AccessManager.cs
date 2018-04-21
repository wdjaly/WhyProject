using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace whyDatabase
{
    class AccessManager : DBManager
    {
        public AccessManager()
        {
        }
        /// <summary>
        /// 创建一个Access数据库对象
        /// </summary>
        public override void CreateDatabase(string HostOrPath = "XJDL_MIIS.lib", string UName = "admin", string UPassword = "xjdl!@#2015", string DBaseName = "")
        {
            this._myDB = new MyAccess(HostOrPath, UName, UPassword, DBaseName);
        }
    }
}
