using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPRLVL;

namespace HaltmannLab
{
    public partial class YAMLEditor : Form
    {
        public Dictionary<string, string> obj;
        public int editorType;

        Objects objs = new Objects();

        List<string> objectKind = new List<string>()
        {
            
        };
        Dictionary<string, string[]> objectSubKind = new Dictionary<string, string[]>()
        {
           
        };
        Dictionary<string, string[]> objectVariation = new Dictionary<string, string[]>()
        {
            
        };
        List<string> itemKind = new List<string>()
        {
            
        };
        Dictionary<string, string[]> itemSubKind = new Dictionary<string, string[]>()
        {
            
        };
        string[] itemVariation = {  };
        Dictionary<string, string[]> bossVariation = new Dictionary<string, string[]>()
        {
            
        };
        Dictionary<string, string[]> enemyVariation = new Dictionary<string, string[]>()
        {
            
        };

        public YAMLEditor()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            yamlDataList.Items.Clear();
            yamlDataList.BeginUpdate();
            foreach(KeyValuePair<string, string> pair in obj)
            {
                yamlDataList.Items.Add(pair.Key);
            }
            yamlDataList.EndUpdate();
        }

        private void YAMLEditor_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> pair in obj)
            {
                yamlDataList.Items.Add(pair.Key);
            }
        }

        private void yamlDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yamlDataList.SelectedItem != null)
            {
                valueSelect.Items.Clear();
                value.Text = obj[yamlDataList.SelectedItem.ToString()];
                /*if (yamlDataList.SelectedItem.ToString() == "string kind")
                {
                    valueSelect.Enabled = true;
                    switch (editorType)
                    {
                        case 0:
                            {
                                valueSelect.Items.AddRange(objs.ObjectList.Keys.ToArray());
                                break;
                            }
                        case 1:
                        case 2:
                            {
                                valueSelect.Items.AddRange(objs.ItemList.Keys.ToArray());
                                break;
                            }
                        case 3:
                            {
                                valueSelect.Items.AddRange(objs.BossList.Keys.ToArray());
                                break;
                            }
                        case 4:
                            {
                                if (obj["string enemyCategory"] == "Enemy")
                                {
                                    valueSelect.Items.AddRange(objs.EnemyList.Keys.ToArray());
                                }
                                else if (obj["string enemyCategory"] == "MBoss")
                                {
                                    valueSelect.Items.AddRange(objs.MBossList.Keys.ToArray());
                                }
                                break;
                            }
                    }
                    valueSelect.Text = value.Text;
                }
                else if (yamlDataList.SelectedItem.ToString() == "string subKind")
                {
                    valueSelect.Enabled = true;
                    switch (editorType)
                    {
                        case 0:
                            {
                                if (objectSubKind.Keys.Contains(obj["string kind"]))
                                {
                                    valueSelect.Items.AddRange(objectSubKind[obj["string kind"]]);
                                    valueSelect.Text = value.Text;
                                }
                                break;
                            }
                        case 1:
                        case 2:
                            {
                                valueSelect.Items.AddRange(itemSubKind[obj["string kind"]]);
                                valueSelect.Text = value.Text;
                                break;
                            }
                    }
                }
                else if (yamlDataList.SelectedItem.ToString() == "string variation")
                {
                    valueSelect.Enabled = true;
                    switch (editorType)
                    {
                        case 0:
                            {
                                if (objectVariation.Keys.Contains(obj["string kind"]))
                                {
                                    valueSelect.Items.AddRange(objectVariation[obj["string kind"]]);
                                    valueSelect.Text = value.Text;
                                }
                                break;
                            }
                        case 1:
                        case 2:
                            {
                                valueSelect.Items.AddRange(itemVariation);
                                valueSelect.Text = value.Text;
                                break;
                            }
                        case 3:
                            {
                                if (bossVariation.Keys.Contains(obj["string kind"]))
                                {
                                    valueSelect.Items.AddRange(bossVariation[obj["string kind"]]);
                                    valueSelect.Text = value.Text;
                                }
                                break;
                            }
                        case 4:
                            {
                                if (enemyVariation.Keys.Contains(obj["string kind"]))
                                {
                                    valueSelect.Items.AddRange(enemyVariation[obj["string kind"]]);
                                    valueSelect.Text = value.Text;
                                }
                                break;
                            }
                    }
                }
                else if (yamlDataList.SelectedItem.ToString() == "string enemyCategory")
                {
                    if (editorType == 4)
                    {
                        valueSelect.Enabled = true;
                    }
                    valueSelect.Items.AddRange(new string[] { "Enemy", "MBoss", "Boss" });
                    valueSelect.Text = value.Text;
                }*/
                //else
                //{
                    valueSelect.Enabled = false;
                //}
            }
        }

        private void value_TextChanged(object sender, EventArgs e)
        {
            obj[yamlDataList.SelectedItem.ToString()] = value.Text;
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void delAttribute_Click(object sender, EventArgs e)
        {
            if (yamlDataList.SelectedItem != null)
            {
                obj.Remove(yamlDataList.SelectedItem.ToString());
                RefreshList();
            }
        }

        private void valueSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            value.Text = valueSelect.Text;
        }
    }
}
