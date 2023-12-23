# MDriveSync

��ƽ̨��ģ�黯����ȫ������ͬ�����߱��ݣ�֧�ְٶ����̡��������̵ȣ����� Duplicati��Kopia �ȶ���ģ�飬֧�ּ��ܻ�ԭ�ȣ�֧�ֵ��򡢾���˫���ͬ�����ݣ���ȫ��ѿ�Դ��

�ṩ Docker �桢Duplicati �桢Kopia �桢Windows ����桢Windows �桢�ֻ��桢��ҳ�桢Linux�桢Mac ��ȶ�ƽ̨�汾��

֧�ֶ����㷨ͬ���뱸�ݡ�

> Ŀǰ��δ������ʽ�棬�����ڴ�~~


A multi-platform, modular, secure cloud drive synchronization and backup tool that supports Baidu Cloud Disk, Alibaba Cloud Disk, and others. Integrates various modules such as Duplicati and Kopia, with features like encryption and restoration. Offers different types of synchronization and backup, including unidirectional, mirror, and bidirectional. The tool is completely free and open source.

Available in multiple platform versions including Docker, Duplicati, Kopia, Windows Service, Windows, Mobile, Web, Linux, and Mac.

Supports a variety of algorithms for synchronization and backup.

> The official version has not yet been released. Stay tuned!


## ��������

- [��������С��������](https://github.com/gaozhangmin/aliyunpan) https://github.com/gaozhangmin/aliyunpan
- [��������С�����(��ͣά��)](https://github.com/liupan1890/aliyunpan) https://github.com/liupan1890/aliyunpan
- [�������������пͻ���](https://github.com/tickstep/aliyunpan) https://github.com/tickstep/aliyunpan

## �߼�����

�ͻ��˸߼����� `appsettings.Client.json`

- `RefreshToken` Ϊ���������������д��[�����ȡ��Ȩ](https://openapi.alipan.com/oauth/authorize?client_id=12561ebaf6504bea8a611932684c86f6&redirect_uri=https://api.duplicati.net/api/open/aliyundrive&scope=user:base,file:all:read&relogin=true)���ƣ����¼������ȡ��Ȩ���ơ�
- `Jobs` �������ö����ҵ���ƻ��е���ҵʱ����Կ������ö��ʱ��㡣

```json
{
  "Client": { // �ͻ��˱���/ͬ������
    "AliyunDrives": [ // ������������
      {
        "Name": "����1", // ��������
        "TokenType": "Bearer", // �������ͣ�������Bearer����
        "AccessToken": "your_access_token", // �������ƣ�����API����
        "RefreshToken": "your_refresh_token", // ˢ�����ƣ����ڻ�ȡ�µķ�������
        "ExpiresIn": 7200, // ���ƹ���ʱ�䣬��λΪ��
        "Metadata": "", // ��������Ԫ��Ϣ�����û���Ϣ��������Ϣ��VIP��Ϣ��
        "Jobs": [ // ��ҵ�б�
          {
            "Id": "1", // ���� ID
            "Name": "gpkopia", // ����/��ҵ����
            "Description": "", // ��ҵ����
            "State": 100, // ��ҵ״̬������ 100 ��ʾ��ͣ��0 ��ʾδ��ʼ
            "Schedules": [ // ��ʱ�ƻ���ʹ��cron���ʽ����
              "0 0/10 * * * ?"
            ],
            "Filters": [ // �ļ������б�
              "**/logs/*"
            ], 
            "Sources": [ // ԴĿ¼�б�
              "E:\\kopia"
            ],
            "Target": "backups/gp", // Ŀ��洢Ŀ¼
            "Restore": "E:\\kopia_restore", // ��ԭĿ¼
            "RapidUpload": true, // �Ƿ������봫����
            "DefaultDrive": "backup", // Ĭ�ϱ��ݵ��������ͣ������̻���Դ��
            "CheckAlgorithm": "sha256", // �ļ��Աȼ���㷨
            "CheckLevel": 1, // �ļ��Աȼ�鼶��
            "FileWatcher": true, // �Ƿ������ļ�ϵͳ����
            "Order": 0, // ������ʾ˳��
            "IsTemporary": false, // �Ƿ�Ϊ��ʱ����
            "UploadThread": 0, // �ϴ�����������
            "DownloadThread": 0, // ���ز���������
            "Metadata": "" // ��ҵԪ��Ϣ
          },
          // ������ҵ����...
        ]
      }
    ]
  }
}

```


> `Schedules` ��ҵ�ƻ�����ʾ��

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

> `Filters` �����ļ�/�ļ���ʾ��

```bash
# �����ļ�ʾ��
# ���� `.exe` ��β�������ļ�
*.duplicatidownload
*.exe                       

# ���Ը�Ŀ¼ʾ������ `/` ��ͷ��ʾ��ǰ����/ͬ���ĸ�Ŀ¼
# ���Ե�ǰ����/ͬ���ĸ�Ŀ¼ `/Recovery/` �µ��ļ��к��ļ�
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

# ���Ը�Ŀ¼����Ŀ¼ʾ��
# ���Ե�ǰ����/ͬ����Ŀ¼�� `/.next/` Ŀ¼�Լ���Ŀ¼�µ������ļ��к��ļ�
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


## ע��

> ע��ϵͳ��־·�����ã���ͬ����ϵͳ֮��Ĳ��졣

```json
# window
"path": "logs\\log.txt"

# linux
"path": "logs/log.txt"
```

## TODO

�ƻ��еĹ�����

- APP ����ʱ��ͨ���ӿڻ�ȡ��ӭ����汾��