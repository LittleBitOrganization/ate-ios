using System;
using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.StorageModule;
using NaughtyAttributes;
using UnityEngine;

namespace DataStorage

{
    [CreateAssetMenu(fileName = "DataInfoReadonly", menuName = "Data/DataInfoReadonly", order = 0)]
    public class InfoDataStorageService : ScriptableObject, IDataInfo, IService
    {
        private const bool True = true;

        [SerializeField, OnValueChanged(nameof(SelectedData))]
        private string find;

        [SerializeField] private List<InfoData> storage = new List<InfoData>();

        [SerializeField] private string findDataKey;


        [SerializeField, DisableIf(nameof(True))]
        private InfoData _data;

        private List<InfoData> _storage = new List<InfoData>();

        private void SelectedData()
        {
#if UNITY_EDITOR
            storage.Clear();
            if (find == string.Empty)
            {
                foreach (var data in _storage)
                {
                    storage.Add(data);
                }
            }
            else
            {
                foreach (var data in _storage)
                {
                    if (data.name.IndexOf(find) != -1)
                    {
                        storage.Add(data);
                    }
                }
            }
#endif
        }

        public void UpdateStorage(Dictionary<string, Data> storage)
        {
#if UNITY_EDITOR
            foreach (var key in storage.Keys)
            {
                _storage.Add(new InfoData(key, storage[key]));
            }

            SelectedData();
#endif
        }

        public void UpdateData(string key, Data data)
        {
#if UNITY_EDITOR
            InfoData infoData = _storage.Find(value => value.name == key);
            if (infoData == null)
            {
                _storage.Add(new InfoData(key, data));
            }
            else
            {
                infoData.UpdateData(data);
            }

            SelectedData();
#endif
        }

        [Button()]
        private void ShowData()
        {
            _data = storage.First((infoData) => infoData.name == findDataKey);
        }


        [Serializable]
        public class InfoData
        {
            [HideInInspector] public string name;
            [SerializeField] [ResizableTextArea] private string _data;

            public InfoData(string name, Data data)
            {
                this.name = name;
                _data = ConvertToString(data);
            }

            public void UpdateData(Data data)
            {
                _data = ConvertToString(data);
            }

            private string ConvertToString(Data data)
            {
                //return JsonUtility.ToJson(data).Replace(",", ",\n");
                return JsonUtility.ToJson(data, True);
            }
        }


        public void Clear()
        {
#if UNITY_EDITOR
            _storage.Clear();
#endif
        }
    }
}
