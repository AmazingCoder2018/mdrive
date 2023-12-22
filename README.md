# MDriveSync

��ƽ̨��ģ�黯����ȫ������ͬ�����߱��ݣ�֧�ְٶ����̡��������̵ȣ����� Duplicati��Kopia �ȶ���ģ�飬֧�ּ��ܻ�ԭ�ȣ�֧�ֵ��򡢾���˫���ͬ�����ݣ���ȫ��ѿ�Դ��

�ṩ Docker �桢Duplicati �桢Kopia �桢Windows ����桢Windows �桢�ֻ��桢��ҳ�桢Linux�桢Mac ��ȶ�ƽ̨�汾��

֧�ֶ����㷨ͬ���뱸�ݡ�

> Ŀǰ��δ������ʽ�棬�����ڴ�~~

## ��������

- [��������С��������](https://github.com/gaozhangmin/aliyunpan) https://github.com/gaozhangmin/aliyunpan
- [��������С�����(��ͣά��)](https://github.com/liupan1890/aliyunpan) https://github.com/liupan1890/aliyunpan
- [�������������пͻ���](https://github.com/tickstep/aliyunpan) https://github.com/tickstep/aliyunpan

## �ͻ��˸߼�����

> appsettings.Client.json

```json
{
  "Client": {
    "AliyunDrives": [
      {
        "Name": "����1",
        "TokenType": "Bearer",
        "AccessToken": "eyJraWQiOiJ***",
        "RefreshToken": "eyJ0eXAiOi****",
        "ExpiresIn": 7200,
        "Metadata": "",
        "Jobs": [
          {
            "Id": "1",
            "Name": "gpkopia",
            "Description": "",
            "State": 100,
            "Schedules": [
              "0 0/10 * * * ?"
            ],
            "Filters": [],
            "Sources": [
              "E:\\kopia"
            ],
            "Target": "backups/gp",
            "Restore": "E:\\kopia_restore",
            "RapidUpload": true,
            "DefaultDrive": "backup",
            "CheckAlgorithm": "sha256",
            "CheckLevel": 1,
            "FileWatcher": true,
            "Order": 0,
            "IsTemporary": false,
            "UploadThread": 0,
            "DownloadThread": 0,
            "Metadata": ""
          },
          {
            "Id": "2",
            "Name": "mykopia",
            "Description": "",
            "State": 100,
            "Schedules": [
              "0 0/10 * * * ?"
            ],
            "Filters": [
              "/Recovery/",
              "/System Volume Information/",
              "/Boot/",
              "/$RECYCLE.BIN/",
              "/@Recycle/",
              "/@Recently-Snapshot/",
              "**/node_modules/**",
              "*.duplicatidownload"
            ],
            "Sources": [
              "F:\\kopia"
            ],
            "Target": "backups/my",
            "Restore": "F:\\kopia_restore",
            "RapidUpload": true,
            "DefaultDrive": "backup",
            "CheckAlgorithm": "sha256",
            "CheckLevel": 1,
            "FileWatcher": true,
            "Order": 0,
            "IsTemporary": false,
            "UploadThread": 0,
            "DownloadThread": 0,
            "Metadata": ""
          },
          {
            "Id": "3",
            "Name": "mytest",
            "Description": "",
            "State": 0,
            "Schedules": [
              "0 * * * * ?"
            ],
            "Filters": [
              "/Recovery/",
              "/System Volume Information/",
              "/Boot/",
              "/$RECYCLE.BIN/",
              "/@Recycle/",
              "/@Recently-Snapshot/",
              "**/node_modules/**",
              "*.duplicatidownload"
            ],
            "Sources": [
              "E:\\test"
            ],
            "Target": "backups/test",
            "Restore": "E:\\kopia_restore",
            "RapidUpload": true,
            "DefaultDrive": "backup",
            "CheckAlgorithm": "sha256",
            "CheckLevel": 1,
            "FileWatcher": true,
            "Order": 0,
            "IsTemporary": false,
            "UploadThread": 0,
            "DownloadThread": 0,
            "Metadata": ""
          }
        ]
      }
    ]
  }
}
```


## ע��

> ע��ϵͳ��־·�����ã���ͬ����ϵͳ֮��Ĳ��졣
```json
# window
"path": "logs\\log.txt"

# linux
"path": "logs/log.txt"
```

## todo
APP ����ʱ��ͨ���ӿڻ�ȡ��ӭ����汾��

```csharp

// cron ���ʽ ���� Quartz 3.8.0
// https://www.bejson.com/othertools/cron/


// ÿ 5 ��
0/5 * * * * ?

// ÿ����
0 * * * * ?

// ÿ 5 ����
0 0/5 * * * ?

// ÿ 10 ����
0 0/10 * * * ?

// ÿ�� 9 ��
0 0 9 * * ?

// ÿ�� 8 �� 10 ��
0 10 8 * * ?

```

## �����ļ���ʾ��
```
/Recovery/*
/Recovery/
/System Volume Information/
/System Volume Information/*
/Boot/
/Boot/*
/$RECYCLE.BIN/*
/$RECYCLE.BIN/
/bootmgr
/bootTel.dat
/@Recycle/*
/@Recently-Snapshot/*
/@Recycle/
/@Recently-Snapshot/
**/@Recycle/*
**/@Recently-Snapshot/*
**/.@__thumb/*
**/@Transcode/*
**/.obsidian/*
**/.git/*
**/.svn/*
**/node_modules/*
**/bin/Debug/*
**/bin/Release/*
**/logs/*
**/obj/*
**/packages/*
**/.next/*
```


## ���Դ���

```

                //using (var scope = _serviceScopeFactory.CreateScope())
                //{
                //    var mediaService = scope.ServiceProvider.GetRequiredService<IMediaService>();
                //    await mediaService.RefreshMetaJob();
                //}

                //_jobs[jobId] = job;
                //var tt = new FastFileSearcher334();
                //tt.Search("E:\\_backups");
                //tt.Test();


        //private void DoWork(object state)
        //{
        //    // �������Է���һ�ظ�ִ��
        //    lock (_lock)
        //    {
        //        // �����趨��ʱ������ֹ�ڵ�ǰ�������ǰ������һ��ִ��
        //        _timer?.Change(Timeout.Infinite, 0);

        //        try
        //        {
        //            _logger.LogInformation("ˢ��ͼƬ����Ƶ��С����ʼ����.");

        //            // ִ��ˢ��ͼƬ����Ƶ��С����
        //            var task = Task.Run(async () => await _mediaService.RefreshMetaJob());
        //            task.Wait();
        //        }
        //        finally
        //        {
        //            // ������ɺ�����������ʱ��
        //            _timer?.Change(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
        //        }
        //    }
        //}
```

```

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

class FileSearcher3
{
    public static ConcurrentBag<string> files = new ConcurrentBag<string>();

    public void Search(string rootPath)
    {
        try
        {
            foreach (var directory in Directory.GetDirectories(rootPath))
            {
                Task.Factory.StartNew(() => Search(directory), TaskCreationOptions.AttachedToParent);
            }

            foreach (var file in Directory.GetFiles(rootPath))
            {
                files.Add(file);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // ����Ȩ������
            Console.WriteLine("Access Denied: " + ex.Message);
        }
        catch (Exception ex)
        {
            // ��������Ǳ�ڵ��쳣
            Console.WriteLine("Exception: " + ex.Message);
        }
    }

    public void DisplayFiles()
    {
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}

class FileSearcher22
{
    public static ConcurrentBag<string> files = new ConcurrentBag<string>();
    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(10); // �������10����������

    public async Task SearchAsync(string rootPath)
    {
        await semaphoreSlim.WaitAsync(); // �ȴ���ȡ�ź���

        try
        {
            string[] directories = Directory.GetDirectories(rootPath);
            string[] filesInCurrentDir = Directory.GetFiles(rootPath);

            foreach (var file in filesInCurrentDir)
            {
                files.Add(file);
            }

            var tasks = new List<Task>();
            foreach (var dir in directories)
            {
                // ����ͬʱ���е���������
                if (semaphoreSlim.CurrentCount == 0)
                {
                    // �ȴ�������������֮һ���
                    await Task.WhenAny(tasks.ToArray());
                    tasks.RemoveAll(t => t.IsCompleted); // �Ƴ�����ɵ�����
                }

                semaphoreSlim.Wait(); // ͬ����ȡ�ź���
                var task = SearchAsync(dir);
                tasks.Add(task);

                // �첽�ͷ��ź��������������������
                task.ContinueWith(t => semaphoreSlim.Release());
            }

            await Task.WhenAll(tasks); // �ȴ������������
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access Denied: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        finally
        {
            semaphoreSlim.Release(); // �ͷ��ź���
        }
    }

    public void DisplayFiles()
    {
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}
class FileSearcher21
{
    public static ConcurrentBag<string> files = new ConcurrentBag<string>();
    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(10); // ���10���߳�

    public async Task SearchAsync(string rootPath)
    {
        await semaphoreSlim.WaitAsync(); // �ȴ��ź���
        try
        {
            string[] directories = Directory.GetDirectories(rootPath);
            string[] filesInCurrentDir = Directory.GetFiles(rootPath);

            foreach (var file in filesInCurrentDir)
            {
                files.Add(file);
            }

            if (directories.Length > 0)
            {
                var tasks = new Task[directories.Length];
                for (int i = 0; i < directories.Length; i++)
                {
                    string dir = directories[i];
                    tasks[i] = SearchAsync(dir);
                }
                await Task.WhenAll(tasks);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // ����Ȩ������
            Console.WriteLine("Access Denied: " + ex.Message);
        }
        catch (Exception ex)
        {
            // ��������Ǳ�ڵ��쳣
            Console.WriteLine("Exception: " + ex.Message);
        }
        finally
        {
            semaphoreSlim.Release(); // �ͷ��ź���
        }
    }

    public void DisplayFiles()
    {
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}

class FileSearcher2
{
    public static ConcurrentBag<string> files = new ConcurrentBag<string>();

    public async Task SearchAsync(string rootPath)
    {
        try
        {
            string[] directories = Directory.GetDirectories(rootPath);
            string[] filesInCurrentDir = Directory.GetFiles(rootPath);

            foreach (var file in filesInCurrentDir)
            {
                files.Add(file);
            }

            if (directories.Length > 0)
            {
                var tasks = new Task[directories.Length];
                for (int i = 0; i < directories.Length; i++)
                {
                    string dir = directories[i];
                    tasks[i] = SearchAsync(dir);
                }
                await Task.WhenAll(tasks);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // ����Ȩ������
            Console.WriteLine("Access Denied: " + ex.Message);
        }
        catch (Exception ex)
        {
            // ��������Ǳ�ڵ��쳣
            Console.WriteLine("Exception: " + ex.Message);
        }
    }

    public void DisplayFiles()
    {
        foreach (var file in files)
        {
            //Console.WriteLine(file);
        }
    }
}


class FileSearcher
{
    public static ConcurrentBag<(string, long, DateTime)> fileInfoBag = new ConcurrentBag<(string, long, DateTime)>();

    private async Task ProcessDirectoryAsync(string directoryPath)
    {
        try
        {
            // ��ȡĿ¼�µ������ļ�����Ŀ¼
            var fileEntries = Directory.GetFiles(directoryPath);
            var directoryEntries = Directory.GetDirectories(directoryPath);

            foreach (var file in fileEntries)
            {
                var fileInfo = new FileInfo(file);
                fileInfoBag.Add((file, fileInfo.Length, fileInfo.CreationTime));
            }

            // ����ÿ����Ŀ¼��ʹ��Task�����첽����
            var tasks = new Task[directoryEntries.Length];
            for (int i = 0; i < directoryEntries.Length; i++)
            {
                var subDir = directoryEntries[i];
                tasks[i] = ProcessDirectoryAsync(subDir);
            }

            await Task.WhenAll(tasks);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access denied to directory {directoryPath}: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing directory {directoryPath}: {ex.Message}");
        }
    }

    public async Task SearchAsync(string rootPath)
    {
        await ProcessDirectoryAsync(rootPath);
    }

    public void DisplayResults()
    {
        foreach (var fileInfo in fileInfoBag)
        {
            //Console.WriteLine($"File: {fileInfo.Item1}, Size: {fileInfo.Item2} bytes, Created: {fileInfo.Item3}");
        }
    }
}

class FileSearcher23
{
    public static ConcurrentBag<string> files = new ConcurrentBag<string>();

    public void Search(string rootPath)
    {
        var options = new ParallelOptions { MaxDegreeOfParallelism = 10 }; // ���10�������߳�

        try
        {
            // ʹ��Parallel.ForEach����������Ŀ¼
            Parallel.ForEach(Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories), options, directory =>
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    files.Add(file);
                }
            });

            // �����Ŀ¼�е��ļ�
            foreach (var file in Directory.GetFiles(rootPath))
            {
                files.Add(file);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access Denied: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }

    public void DisplayFiles()
    {
        foreach (var file in files)
        {
            //Console.WriteLine(file);
        }
    }
}
class Program
{
    static async Task Main(string[] args)
    {


        //var searcher = new FileSearcher();
        //await searcher.SearchAsync("C:\\your\\path"); // �滻Ϊ�����ʼ·��
        //searcher.DisplayResults();

        var sw = new Stopwatch();
        sw.Start();
        var searcher = new FileSearcher23();
         searcher.Search("E:\\program_files"); // �滻Ϊ�����ʼ·��
        searcher.DisplayFiles();

        //var searcher = new FileSearcher();
        //await searcher.SearchAsync("E:\\program_files"); // �滻Ϊ�����ʼ·��
        //searcher.DisplayResults();
        //sw.Stop();

        Console.WriteLine("end, " + FileSearcher23.files.Count + ", " + sw.ElapsedMilliseconds);
        Console.ReadKey();
    }
}


//using System;
//using System.Collections.Concurrent;
//using System.IO;
//using System.IO.MemoryMappedFiles;
//using System.Threading.Tasks;

//class FileSearcher
//{
//    private ConcurrentDictionary<string, string> fileContents = new ConcurrentDictionary<string, string>();

//    private async Task ProcessFileAsync(string filePath)
//    {
//        try
//        {
//            // ʹ���ڴ�ӳ���ļ���ȡ�ļ�����
//            using (var mappedFile = MemoryMappedFile.CreateFromFile(filePath))
//            {
//                using (var reader = new StreamReader(mappedFile.CreateViewStream()))
//                {
//                    var content = await reader.ReadToEndAsync();
//                    fileContents.TryAdd(filePath, content);
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
//        }
//    }

//    public async Task SearchAsync(string rootPath)
//    {
//        var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
//        var tasks = new List<Task>();

//        foreach (var file in files)
//        {
//            tasks.Add(ProcessFileAsync(file));
//        }

//        await Task.WhenAll(tasks);
//    }

//    public void DisplayResults()
//    {
//        foreach (var kvp in fileContents)
//        {
//            Console.WriteLine($"{kvp.Key}: {kvp.Value.Length} characters");
//        }
//    }
//}

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        var searcher = new FileSearcher();
//        await searcher.SearchAsync("E:\\_todo\\___guanpeng"); // �滻Ϊ�����ʼ·��
//        searcher.DisplayResults();

//        Console.WriteLine("end");
//        Console.ReadKey();
//    }
//}

```