namespace MDriveSync.Core.IO
{
    /// <summary>
    /// ���ڷ�װSystem.IO�����Ľӿڡ�
    /// </summary>
    public interface ISystemIO
    {
        // ��ȡĿ¼��Ŀ
        IFileEntry DirectoryEntry(string path);

        // ����Ŀ¼
        void DirectoryCreate(string path);

        // ɾ��Ŀ¼
        void DirectoryDelete(string path, bool recursive);

        // ���Ŀ¼�Ƿ����
        bool DirectoryExists(string path);

        // �ƶ�Ŀ¼
        void DirectoryMove(string sourceDirName, string destDirName);

        // ����Ŀ¼�����д��ʱ�䣨UTC��
        void DirectorySetLastWriteTimeUtc(string path, DateTime time);

        // ����Ŀ¼�Ĵ���ʱ�䣨UTC��
        void DirectorySetCreationTimeUtc(string path, DateTime time);

        // ��ȡ�ļ���Ŀ
        IFileEntry FileEntry(string path);

        // �ƶ��ļ�
        void FileMove(string source, string target);

        // ɾ���ļ�
        void FileDelete(string path);

        // �����ļ�
        void FileCopy(string source, string target, bool overwrite);

        // �����ļ������д��ʱ�䣨UTC��
        void FileSetLastWriteTimeUtc(string path, DateTime time);

        // �����ļ��Ĵ���ʱ�䣨UTC��
        void FileSetCreationTimeUtc(string path, DateTime time);

        // ��ȡ�ļ������д��ʱ�䣨UTC��
        DateTime FileGetLastWriteTimeUtc(string path);

        // ��ȡ�ļ��Ĵ���ʱ�䣨UTC��
        DateTime FileGetCreationTimeUtc(string path);

        // ����ļ��Ƿ����
        bool FileExists(string path);

        // ��ȡ�ļ�����
        long FileLength(string path);

        // ���ļ����ж�ȡ
        FileStream FileOpenRead(string path);

        // ���ļ�����д��
        FileStream FileOpenWrite(string path);

        // �����ļ�
        FileStream FileCreate(string path);

        // ��ȡ�ļ�����
        FileAttributes GetFileAttributes(string path);

        // �����ļ�����
        void SetFileAttributes(string path, FileAttributes attributes);

        // ������������
        void CreateSymlink(string symlinkfile, string target, bool asDir);

        // ��ȡ�������ӵ�Ŀ��
        string GetSymlinkTarget(string path);

        // ��ȡĿ¼����
        string PathGetDirectoryName(string path);

        // ��ȡ�ļ���
        string PathGetFileName(string path);

        // ��ȡ�ļ���չ��
        string PathGetExtension(string path);

        // �����ļ���չ��
        string PathChangeExtension(string path, string extension);

        // ���·��
        string PathCombine(params string[] paths);

        // ��ȡ����·��
        string PathGetFullPath(string path);

        // ��ȡ·���ĸ�����
        string GetPathRoot(string path);

        // ��ȡָ��·���µ�����Ŀ¼
        string[] GetDirectories(string path);

        // ��ȡָ��·���µ������ļ�
        string[] GetFiles(string path);

        // ʹ������ģʽ��ȡָ��·���µ������ļ�
        string[] GetFiles(string path, string searchPattern);

        // ��ȡ�ļ��Ĵ���ʱ�䣨UTC��
        DateTime GetCreationTimeUtc(string path);

        // ��ȡ�ļ������д��ʱ�䣨UTC��
        DateTime GetLastWriteTimeUtc(string path);

        // ö���ļ�ϵͳ��Ŀ
        IEnumerable<string> EnumerateFileSystemEntries(string path);

        // ö���ļ�
        IEnumerable<string> EnumerateFiles(string path);

        // ʹ������ģʽ������ѡ��ö���ļ�
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);

        // ö��Ŀ¼
        IEnumerable<string> EnumerateDirectories(string path);

        // ����Ԫ����
        void SetMetadata(string path, Dictionary<string, string> metdata, bool restorePermissions);

        // ��ȡԪ����
        Dictionary<string, string> GetMetadata(string path, bool isSymlink, bool followSymlink);
    }
}
