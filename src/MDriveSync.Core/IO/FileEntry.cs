namespace MDriveSync.Core.IO
{
    /// <summary>
    /// �ļ��ӿڵ���Ҫʵ����
    /// </summary>
    public class FileEntry : IFileEntry
    {
        private string m_name;
        private DateTime m_lastAccess;
        private DateTime m_lastModification;
        private long m_size;
        private bool m_isFolder;

        /// <summary>
        /// ��ȡ�������ļ����ļ��е�����
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// ��ȡ�������ļ����ļ��������ʵ�ʱ��
        /// </summary>
        public DateTime LastAccess
        {
            get { return m_lastAccess; }
            set { m_lastAccess = value; }
        }

        /// <summary>
        /// ��ȡ�������ļ����ļ�������޸ĵ�ʱ��
        /// </summary>
        public DateTime LastModification
        {
            get { return m_lastModification; }
            set { m_lastModification = value; }
        }

        /// <summary>
        /// ��ȡ�������ļ����ļ��еĴ�С
        /// </summary>
        public long Size
        {
            get { return m_size; }
            set { m_size = value; }
        }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ��Ŀ�Ƿ�Ϊ�ļ���
        /// </summary>
        public bool IsFolder
        {
            get { return m_isFolder; }
            set { m_isFolder = value; }
        }

        /// <summary>
        /// �������������ڽ�ʵ����ʼ��ΪĬ��ֵ
        /// </summary>
        private FileEntry()
        {
            m_name = null;
            m_lastAccess = new DateTime();
            m_lastModification = new DateTime();
            m_size = -1;
            m_isFolder = false;
        }

        /// <summary>
        /// ��ʹ�����ƹ�����Ŀ��
        /// Ĭ�ϼٶ�����ĿΪ�ļ���
        /// </summary>
        /// <param name="filename">�ļ�������</param>
        public FileEntry(string filename)
            : this()
        {
            m_name = filename;
        }

        /// <summary>
        /// ʹ�����ƺʹ�С������Ŀ��
        /// Ĭ�ϼٶ�����ĿΪ�ļ���
        /// </summary>
        /// <param name="filename">�ļ�������</param>
        /// <param name="size">�ļ��Ĵ�С</param>
        public FileEntry(string filename, long size)
            : this(filename)
        {
            m_size = size;
        }

        /// <summary>
        /// �ṩ������Ϣ������Ŀ
        /// </summary>
        /// <param name="filename">�ļ����ļ��е�����</param>
        /// <param name="size">�ļ����ļ��еĴ�С</param>
        /// <param name="lastAccess">�ļ����ļ��������ʵ�ʱ��</param>
        /// <param name="lastModified">�ļ����ļ�������޸ĵ�ʱ��</param>
        public FileEntry(string filename, long size, DateTime lastAccess, DateTime lastModified)
            : this(filename, size)
        {
            m_lastModification = lastModified;
            m_lastAccess = lastAccess;
        }
    }
}