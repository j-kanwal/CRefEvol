using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace CRefEvol
{
    public partial class Form1 : Form
    {
        private DataTable outPutTable, outPutTable2, outPutTable3, fccTable;
        private DataTable fileTable, fileTableGen, mcsTable, GenTable, outPutTableRefP, outPutTableRef;
        private DataSet dtSett1, dtSett2, dtSett3, dtSett4;
        //private List<mcs_node> gen_nodelist;
        //private List<mcs_node> stgen_nodelist;
        private List<CloneClass> cloneList = new List<CloneClass>();
        private List<CloneClass> MCScloneList = new List<CloneClass>();
        private List<CloneClass> MCCcloneList = new List<CloneClass>();
        private int gen_ID, st_gen_ID, pageNo;
        private bool genclick = false;
        private bool cc_click = false;
        private bool ref_click = false;
        private List<string> listFccFilesforGen; 
        public Form1()
        {
            InitializeComponent();
            

            char[] comma = { ',' };

            char[] ch = { ' ', '(', ')', ',', ':', '\t' };
            char[] chdot = { '.', ' ', '(', ')', ',', ':', '\t' };
            char[] space = { ' ' };
            char[] colon = { '\'', '$', '1', '2', '3', '4', '5', '6', '7' };
            char[] singlecolon = { '\'' };
            char[] bslash = { '\\' };
            //char[] dirchar = { 'D', ':', '/' };         



            char[] splitsighns = { '"', ',', };

            outPutTable = new DataTable("OutPut Table");

            outPutTable2 = new DataTable("OutPut Table");
            outPutTable3 = new DataTable("OutPut Table");
            fccTable = new DataTable("OutPut Table");
            fileTable = new DataTable("OutPut Table");
            //mcsTable = new DataTable("OutPut Table");
           // GenTable = new DataTable("OutPut Table");
            outPutTableRefP = new DataTable("OutPut Table");
            //fileTableGen = new DataTable("OutPut Table");


            /////========  GenTable table =========

            DataColumn dtColumnt2;

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "No.";
            //dtColumnt2.Caption = "No.";
            //dtColumnt2.ReadOnly = true;
            //GenTable.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "Gen. ID";
            //dtColumnt2.Caption = "Gen. ID";
            //dtColumnt2.ReadOnly = true;
            //GenTable.Columns.Add(dtColumnt2);

            /////======== file table =========

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "File No.";
            dtColumnt2.Caption = "File No.";
            dtColumnt2.ReadOnly = true;
            fileTable.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.String");
            dtColumnt2.ColumnName = "File Name";
            dtColumnt2.Caption = "File Name";
            dtColumnt2.ReadOnly = true;
            fileTable.Columns.Add(dtColumnt2);
            /////======== file table Gen =========

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "File No.";
            //dtColumnt2.Caption = "File No.";
            //dtColumnt2.ReadOnly = true;
            //fileTableGen.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.String");
            //dtColumnt2.ColumnName = "File Name";
            //dtColumnt2.Caption = "File Name";
            //dtColumnt2.ReadOnly = true;
            //fileTableGen.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.String");
            //dtColumnt2.ColumnName = "Gen. IDs";
            //dtColumnt2.Caption = "Gen. IDs";
            //dtColumnt2.ReadOnly = true;
            //fileTableGen.Columns.Add(dtColumnt2);
            //======= mcs table ===========

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "No.";
            //dtColumnt2.Caption = "No.";
            //dtColumnt2.ReadOnly = true;
            //mcsTable.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.String");
            //dtColumnt2.ColumnName = "Method Name";
            //dtColumnt2.Caption = "Method Name";
            //dtColumnt2.ReadOnly = true;
            //mcsTable.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.String");
            //dtColumnt2.ColumnName = "Directory";
            //dtColumnt2.Caption = "Directory";
            //dtColumnt2.ReadOnly = true;
            //mcsTable.Columns.Add(dtColumnt2);

            /////////////


            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "No.";
            //dtColumnt2.Caption = "No.";
            //dtColumnt2.ReadOnly = true;
            //outPutTable.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "Gen. ID";
            //dtColumnt2.Caption = "Gen. ID";
            //dtColumnt2.ReadOnly = true;
            //outPutTable.Columns.Add(dtColumnt2);

            //dtColumnt2 = new DataColumn();
            //dtColumnt2.DataType = Type.GetType("System.Int32");
            //dtColumnt2.ColumnName = "Gen. Life";
            //dtColumnt2.Caption = "Gen. Life";
            //dtColumnt2.ReadOnly = true;
            //outPutTable.Columns.Add(dtColumnt2);


            //// =============== table 2 ===========   

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "No.";
            dtColumnt2.Caption = "No.";
            dtColumnt2.ReadOnly = true;
            outPutTable2.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "Clone ID";
            dtColumnt2.Caption = "Clone ID";
            dtColumnt2.ReadOnly = true;
            outPutTable2.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.String");
            dtColumnt2.ColumnName = "Method Name";
            dtColumnt2.Caption = "Method Name";
            dtColumnt2.ReadOnly = true;
            outPutTable2.Columns.Add(dtColumnt2);


            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "Begin Line No.";
            dtColumnt2.Caption = "Begin Line No.";
            outPutTable2.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "End Line No.";
            dtColumnt2.Caption = "End Line No.";
            outPutTable2.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.String");
            dtColumnt2.ColumnName = "Directory";
            dtColumnt2.Caption = "Directory";
            dtColumnt2.ReadOnly = true;
            outPutTable2.Columns.Add(dtColumnt2);


            //========== table 3 =========

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "No.";
            dtColumnt2.Caption = "No.";
            dtColumnt2.ReadOnly = true;
            outPutTable3.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "Clone ID";
            dtColumnt2.Caption = "Clone ID";
            dtColumnt2.ReadOnly = true;
            outPutTable3.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "Clone Size";
            dtColumnt2.Caption = "Clone Size";
            dtColumnt2.ReadOnly = true;
            outPutTable3.Columns.Add(dtColumnt2);

            //========== fcc table ==============

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "No.";
            dtColumnt2.Caption = "No.";
            dtColumnt2.ReadOnly = true;
            fccTable.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.Int32");
            dtColumnt2.ColumnName = "Clone ID";
            dtColumnt2.Caption = "Clone ID";
            dtColumnt2.ReadOnly = true;
            fccTable.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.String");
            dtColumnt2.ColumnName = "File";
            dtColumnt2.Caption = "File";
            dtColumnt2.ReadOnly = true;
            fccTable.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.String");
            dtColumnt2.ColumnName = "Method Names";
            dtColumnt2.Caption = "Method Names";
            dtColumnt2.ReadOnly = true;
            fccTable.Columns.Add(dtColumnt2);

            dtColumnt2 = new DataColumn();
            dtColumnt2.DataType = Type.GetType("System.String");
            dtColumnt2.ColumnName = "Directory";
            dtColumnt2.Caption = "Directory";
            dtColumnt2.ReadOnly = true;
            fccTable.Columns.Add(dtColumnt2);
            // ========= outPutTableRefP ==================
            // outPutTableRefP = new DataTable();
            DataColumn dtColumnRP;

            dtColumnRP = new DataColumn();
            dtColumnRP.DataType = Type.GetType("System.Int32");
            dtColumnRP.ColumnName = "No.";
            dtColumnRP.Caption = "No.";
            dtColumnRP.ReadOnly = true;
            outPutTableRefP.Columns.Add(dtColumnRP);

            dtColumnRP = new DataColumn();
            dtColumnRP.DataType = Type.GetType("System.String");
            dtColumnRP.ColumnName = "Refactoring Patterns";
            dtColumnRP.Caption = "Refactoring Patterns";
            dtColumnRP.ReadOnly = true;
            outPutTableRefP.Columns.Add(dtColumnRP);

            dtColumnRP = new DataColumn();
            dtColumnRP.DataType = Type.GetType("System.Int32");
            dtColumnRP.ColumnName = "Frequency";
            dtColumnRP.Caption = "Frequency";
            dtColumnRP.ReadOnly = true;
            outPutTableRefP.Columns.Add(dtColumnRP);

            //======= outPutTableRef ==============
            outPutTableRef = new DataTable("OutPut Table");
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.Int32");
            dtColumn.ColumnName = "No.";
            dtColumn.Caption = "No.";
            dtColumn.ReadOnly = true;
            outPutTableRef.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "Method";
            dtColumn.Caption = "Method";
            outPutTableRef.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "Refactoring Type";
            dtColumn.Caption = "Refactoring Type";
            outPutTableRef.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "File"; //file name
            dtColumn.Caption = "File";
            outPutTableRef.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "Directory"; //file name
            dtColumn.Caption = "Directory";
            outPutTableRef.Columns.Add(dtColumn);

        }

        // Structures

        public class CloneClass
        {
            public int clone_size, clone_id;
            public int[] mcc_ids;
            public bool within_file;
            public List<cloneinstance> cloninstances = new List<cloneinstance>();
           // public List<fccinstance> fccInstances = new List<fccinstance>();
        }


        public class cloneinstance
        {
            public string method, file, fpath, codefragment;
            public int start_line_no, end_line_no, mcc_id, cf_length;
            // public cloneinstance fcc;

        }
        public struct CodeRef
        {
            //public int clone_size, clone_id, ref_size;
            //public bool is_ref;

            public string Type, Loc, method, file;

            // public List<string> cloninstances;
        }
        public struct RefInstance
        {
            public int clone_ID, clone_size;
            //public string cloninstance;
            public string Type, Loc, method, file, fname, fpath;
        }

        public class RefClone
        {
            public int clone_id, size;
            public List<RefInstance> refcloninstances = new List<RefInstance>();
        }


        // ===================== Classes ======================

        class Clones
        {
            List<CloneClass> ccl = new List<CloneClass>();
            // List<string> list_mf = new List<string>();
           // List<int> list_mcc_id = new List<int>();

            OpenFileDialog fdlg = new OpenFileDialog();

            public string readfile;
            char[] line = { '\r', '\n' };
            char[] tab = { '\t' };
            char[] slash = { '/' };
            char[] dir = { 'D', ':', '/' };

            public void take_readfile()
            {
                // fdlg.InitialDirectory = @"D:\RESEARCH\structural clone evol\";
                fdlg.InitialDirectory = @"D:\RESEARCH\PhD thesis\tool support for clone management\clones for tool\";
                fdlg.Title = "Enter  next version clone file";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                    readfile = fdlg.FileName;
                // readfile=rfile;
            }

            public cloneinstance method_file(string[] clonecols)
            {
                string method, file, rline, codefrag = "", path;
                string[] filepath, pathcols;
                int row_no;


                method = clonecols[1];

                filepath = clonecols[2].Split(slash);
                file = filepath[filepath.Length - 1];
                cloneinstance cci = new cloneinstance();
                cci.method = method;
                cci.file = file;
                cci.fpath = clonecols[2];
                if (clonecols.Length > 4)
                {
                    cci.start_line_no = Int32.Parse(clonecols[3]);
                    cci.end_line_no = Int32.Parse(clonecols[4]);
                    cci.cf_length = cci.end_line_no - cci.start_line_no;
                }
                else if (clonecols.Length == 4)
                    cci.mcc_id = Int32.Parse(clonecols[3]);

                //=== ==== extracting clone code fragment ======
                try
                {
                    pathcols = cci.fpath.Split(slash);
                    path = cci.fpath.TrimStart(dir);
                    //using (StreamReader sr = new StreamReader(path))
                    //{
                    //    row_no = 1;
                    //    while (sr.EndOfStream == false)
                    //    {
                    //        rline = sr.ReadLine();
                    //        if (row_no >= cci.start_line_no && row_no <= cci.end_line_no)
                    //        {
                    //            //if(rline.Contains(nodeinst.method)==true) // trim closing braket
                    //            codefrag += row_no.ToString() + " " + rline + "\n";
                    //        }
                    //        row_no++;
                    //    }
                    //}
                    cci.codefragment = codefrag;

                    return cci;
                }// end of try
                catch (FileNotFoundException e)
                {
                    return cci;
                }

            }
            public List<CloneClass> Clone_Classes()
            {
                string line;
                string[] clonecols;
                List<cloneinstance> list_inst = new List<cloneinstance>();
                int clonelength = 1, clonecount = 0, clone_id, prev_cid = 0;
                CloneClass cc;
                //CloneClass[] ccarray, ccarray2;

                using (StreamReader clones = new StreamReader(readfile))
                {
                    // reading next version clones
                    line = clones.ReadLine();
                    clonecols = line.Split(tab);
                    clone_id = Int32.Parse(clonecols[0]);

                    prev_cid = clone_id;

                    while (clones.EndOfStream == false)
                    {
                        // cc.mcc_id = Int32.Parse(clonecols[3]);
                        while (clone_id == prev_cid)
                        {
                            list_inst.Add(method_file(clonecols));

                            //  list_mcc_id.Add(Int32.Parse(clonecols[3]));

                            clonecount++;

                            if (clones.EndOfStream == true)
                                break;

                            prev_cid = clone_id;
                            line = clones.ReadLine();
                            clonecols = line.Split(tab);
                            clone_id = Int32.Parse(clonecols[0]);
                        }
                        cc = new CloneClass();
                        cc.clone_id = prev_cid;

                        cc.clone_size = clonecount;
                        cc.cloninstances = new List<cloneinstance>(list_inst); //list_mf.ToArray();
                        //cc.mcc_ids = list_mcc_id.ToArray();
                        ccl.Add(cc);
                        //sw.WriteLine(cc.clone_id.ToString() + "\t" + clonecount.ToString());
                        list_inst.Clear();
                        //list_mcc_id.Clear();
                        clonecount = 0;
                        prev_cid = clone_id;
                        // clonelength++;
                    }
                }

                return ccl;
            }

           
           

        } //////////////////////////////////////////////////////////
        //================ End of Class ====================
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// /////////Refactoring class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        class Refactoring
        {
            public List<String> list_refclones = new List<string>();
            public List<CloneClass> list_refclclases = new List<CloneClass>();
            public List<CloneClass> ref_ccl = new List<CloneClass>();
            public List<RefInstance> list_ref = new List<RefInstance>();
            public List<CloneClass> ccl = new List<CloneClass>();
            public List<RefClone> list_refcloneclases = new List<RefClone>();
            public SortedList<string, int> sl = new SortedList<string, int>();

            public void clones(List<CloneClass> list_cc)
            {
                ccl = new List<CloneClass>(list_cc);
            }
            public void read_Refactoring()
            {
                char[] splitsighns = { '"', ',', };
                char[] icomma = { '"' };
                char[] percentage = { '%', '#' };
                char[] slashdot = { '/', '.' };
                char[] paranthesis = { ')', '(' };
                bool is_ref = false;
                string line, ref_method, ref_file;
                string[] ref_att, ref_path;

                RefInstance ref_cc = new RefInstance();

                string readfile_ref;

                // readfile_ref = take_readfile("refactoring");
                readfile_ref = "clones for tool/refactoring/v7.5_7.6.RUB";
                // readfile_ref = "D:/RESEARCH/cloneevolution refactring/refactoring and clones/JhotDraw/ref 7.1_7.2.RUB"; 
                using (StreamReader refact = new StreamReader(readfile_ref))
                {

                    while (refact.EndOfStream == false)
                    {
                        line = refact.ReadLine();
                        ref_att = line.Split(splitsighns, StringSplitOptions.RemoveEmptyEntries);

                        if (ref_att[0].Contains("move_method") == true)
                        {
                            ref_cc.Type = ref_att[0];
                            ref_method = ref_att[1];
                            ref_method = ref_method.TrimEnd(paranthesis);
                            ref_path = ref_att[2].Split(percentage);
                            ref_file = ref_path[1];
                            ref_file = ref_file.TrimStart(slashdot);
                            ref_cc.method = ref_method;
                            ref_cc.file = ref_file;
                            ref_cc.Loc = ref_att[2];
                            is_ref = true;
                        }
                        if (ref_att[0].Contains("add_parameter") || ref_att[0].Contains("replace_nested_cond_guard_clauses") == true || ref_att[0].Contains("remove_parameter") == true || ref_att[0].Contains("consolidate_duplicate_cond_fragments") == true || ref_att[0].Contains("replace_method_with_method_object") == true || ref_att[0].Contains("replace_magic_number_with_constant") == true || ref_att[0].Contains("inline_method") == true || ref_att[0].Contains("remove_assignment_to_parameters") == true || ref_att[0].Contains("replace_temp_with_query") == true || ref_att[0].Contains("rename_method") == true || ref_att[0].Contains("consolidate_cond_expression") == true || ref_att[0].Contains("extract_method") == true)
                        {
                            ref_cc.Type = ref_att[0];
                            ref_path = ref_att[1].Split(percentage);
                            ref_method = ref_path[2];
                            ref_method = ref_method.TrimEnd(paranthesis);
                            ref_file = ref_path[1];
                            ref_file = ref_file.TrimStart(slashdot);
                            ref_cc.method = ref_method;
                            ref_cc.file = ref_file;
                            ref_cc.Loc = ref_att[2];
                            is_ref = true;
                        }

                        if (ref_att[0].Contains("extract_interface") == true)   //(ref_att[0].Contains("replace_exception_with_test")==true || 
                        {
                            ref_cc.Type = ref_att[0];
                            ref_path = ref_att[2].Split(percentage);
                            ref_cc.method = "";
                            ref_file = ref_path[1];
                            ref_file = ref_file.TrimStart(slashdot);

                            ref_cc.file = ref_file;
                            ref_cc.Loc = ref_att[2];
                            is_ref = true;
                        }

                        if (ref_att[0].Contains("introduce_explaining_variable") == true)
                        {
                            ref_cc.Type = ref_att[0];
                            ref_att = line.Split(icomma);
                            ref_path = ref_att[5].Split(percentage);
                            ref_method = ref_path[2];
                            ref_method = ref_method.TrimEnd(paranthesis);
                            ref_file = ref_path[1];
                            ref_file = ref_file.TrimStart(slashdot);
                            ref_cc.method = ref_method;
                            ref_cc.file = ref_file;
                            ref_cc.Loc = ref_att[2];
                            is_ref = true;

                        }
                        if (is_ref == true)
                            this.list_ref.Add(ref_cc);

                        is_ref = false;
                        //sw.WriteLine(cc.clone_id.ToString() + "\t" + clonecount.ToString());


                    }
                }
            }
            //======================================= Ref mapping ===========================
            public void mapping_refclones()
            {
                // matching of clones with refactorings
                string fname = "", method = "", fpath = "", refclone_att = "";
                string[] ccinstarray, cc_att, path;
                List<cloneinstance> list_ccinst;
                List<string> clone_M_and_F = new List<string>();
                RefInstance refi = new RefInstance();
                string methodfile;
                char[] slashdot = { '/', '.' };
                char[] paranthesis = { ')', '(', ' ' };
                bool unique = false, match = false;
                int no_of_inst = 0;

                foreach (CloneClass cc in this.ccl)
                {
                    RefClone ref_cc = new RefClone();
                    no_of_inst = 0;
                    ref_cc.clone_id = cc.clone_id;
                    // ref_cc.refcloninstances = null;
                    list_ccinst = new List<cloneinstance>(cc.cloninstances);
                    // ccinstarray = cc.cloninstances.ToArray();
                    foreach (cloneinstance cc_inst in list_ccinst)
                    {
                        unique = false;
                        methodfile = cc_inst.method + "." + cc_inst.file;
                        if (clone_M_and_F.Contains(methodfile) == false)
                        {
                            clone_M_and_F.Add(methodfile);
                            unique = true;
                        }

                        if (unique == true)
                        {
                            foreach (RefInstance cr1 in this.list_ref)
                            {
                                //cc_att = cc_inst.Split(tab);
                                method = cc_inst.method;
                                method = method.TrimEnd(paranthesis);
                                //fpath = cc_att[1];
                                fpath = cc_inst.fpath;
                                path = fpath.Split(slashdot);
                                fname = path[path.Length - 2]; // excluding .java

                                refi = new RefInstance();

                                if (cr1.method.Equals(method) == true && cr1.file.Equals(fname) == true)
                                {
                                    refi.clone_ID = cc.clone_id;
                                    refi.method = cr1.method + "()";
                                    refi.fpath = fpath;
                                    refi.Type = cr1.Type.TrimEnd("(".ToCharArray());
                                    refi.Loc = cr1.Loc;
                                    refi.fname = fname;
                                    ref_cc.refcloninstances.Add(refi);
                                    no_of_inst++;
                                    refclone_att = cc.clone_id.ToString() + "\t" + cr1.method + "\t" + fpath + "\t" + cr1.Type + "\t" + cr1.Loc;

                                    this.list_refclones.Add(refclone_att);
                                    match = true;
                                }
                            }
                        }
                    }
                    // //ref clone classes
                    if (match == true)
                    {
                        ref_cc.size = ref_cc.refcloninstances.Count();
                        this.list_refclclases.Add(cc);
                        this.list_refcloneclases.Add(ref_cc);
                    }
                    match = false;
                }
                // this.uniqueclone_inst = clone_M_and_F.Count; //?

            }
            //=============== Refactoring Types ==============
            public void RefTypes()
            {
                //string[] ref_att;
                string ref_type;
                bool InsideOfList = false;
                foreach (RefClone refcc in this.list_refcloneclases)
                //foreach (string s in this.list_refclones)
                {
                    foreach (RefInstance refinst in refcc.refcloninstances)
                    {
                        // ref_att = s.Split(tab, StringSplitOptions.RemoveEmptyEntries);
                        ref_type = refinst.Type;//ref_att[3];
                        InsideOfList = false;

                        for (int i = 0; i < this.sl.Count; i++)
                        {
                            if (this.sl.ElementAt(i).Key == ref_type)
                            {
                                var val = this.sl.ElementAt(i).Value + 1;
                                this.sl.RemoveAt(i);
                                this.sl.Add(ref_type, val);
                                InsideOfList = true;
                            }
                        }
                        if (InsideOfList == false)
                        {
                            this.sl.Add(ref_type, 1);
                        }
                    }
                }
            }
            ///================ Removed Clones ===================
            public List<CloneClass> list_aliveclone = new List<CloneClass>();
            public List<CloneClass> list_deadclones = new List<CloneClass>();
            public List<string> list_removedrefinstances = new List<string>();

            public void removedClones()
            {
                List<CloneClass> ccl2 = new List<CloneClass>();
                bool clone_match = false, mdotf_match = false;
                int deadclonecount = 0, match_count = 0;
                string[] ref_cols, cloncols;
                string method, ref_method, file, ref_file;
                Clones objremoveCC = new Clones();
                //objremoveCC.readclones("next version");
                objremoveCC.readfile = "clones for tool/refactoring/label v7.6.txt";
                //objremoveCC.readfile = "D:/RESEARCH/cloneevolution refactring/refactoring and clones/JhotDraw/labelv7.2 scc.txt";
                ccl2 = objremoveCC.Clone_Classes();
                Refactoring objremoveCC_Ref = new Refactoring();
                objremoveCC_Ref.clones(ccl2);
                //ccl2 = readclones();
                char[] tabslash = { '\t', '/' };

                foreach (CloneClass cci_ref in this.list_refclclases)
                {
                    clone_match = false;
                    foreach (CloneClass cci in objremoveCC_Ref.ccl)
                    {
                        //if (cci.clone_size == cci_ref.clone_size)
                        //    clone_match = true;
                        match_count = 0;
                        //  foreach (string ref_s in cci_ref.cloninstances)
                        foreach (cloneinstance ref_s in cci_ref.cloninstances)
                        {
                            mdotf_match = false;
                            ref_method = ref_s.method;
                            ref_cols = ref_s.fpath.Split(tabslash);
                            //ref_method = ref_cols[0];
                            ref_file = ref_cols[ref_cols.Length - 2] + "/" + ref_cols[ref_cols.Length - 1];
                            foreach (cloneinstance cci_inst in cci.cloninstances)
                            {
                                cloncols = cci_inst.fpath.Split(tabslash);
                                //                                 cloncols = cci_inst.Split(tabslash);
                                method = cci_inst.method; //cloncols[0];
                                file = cloncols[cloncols.Length - 2] + "/" + cloncols[cloncols.Length - 1]; //foldername/filename 

                                if (method.Equals(ref_method) == true && file.Equals(ref_file) == true)
                                {
                                    mdotf_match = true;
                                    match_count++;
                                    //objremoveCC.list_refclones.Add();
                                    break;      //ok
                                }
                            }
                        }
                        if (match_count >= 2)
                        {
                            this.list_aliveclone.Add(cci_ref);
                            break;
                        }
                    }
                    if (match_count < 2)
                        this.list_deadclones.Add(cci_ref);
                }
                string[] ref_att;
                int cid = 0;
                List<string> list_deadrefCC = new List<string>();
                foreach (CloneClass deadCC in this.list_deadclones)
                {

                    foreach (RefClone ref_CC in this.list_refcloneclases)
                    {
                        //ref_att = ref_s.Split(tab, StringSplitOptions.RemoveEmptyEntries);
                        //cid = Int32.Parse(ref_att[0]);
                        //if (cid == deadCC.clone_id)
                        if (ref_CC.clone_id == deadCC.clone_id)
                        {
                            objremoveCC_Ref.list_refcloneclases.Add(ref_CC);
                            // list_deadrefCC.Add(s);
                            break;
                        }
                    }
                }
                ///////////////////////// objremoveCC_Ref.consistentclones();
                objremoveCC_Ref.RefTypes();
                //objremoveCC_Ref.write_file();

            }
            //=================== consistent clones =====================

            public List<CloneClass> list_consclones = new List<CloneClass>();
            public List<CloneClass> list_inconsclones = new List<CloneClass>();

            public void consistentclones()
            {
                // List<CloneClass> list_ref = new List<CloneClass>(); // total clone refactoring
                //Clones refclonCC = new Clones();
                //refclonCC.make_cloneclass(this.list_refclones);  //make clone class of refactored instances only
                //list_ref = make_cloneclass(list_refclones); // clone refactoring

                foreach (RefClone cci_ref in this.list_refcloneclases) //this.list_refclclases)
                    foreach (CloneClass cci in this.ccl)

                        if (cci.clone_id == cci_ref.clone_id)
                        {
                            // clone_classes++;           //// total clone classes refactored
                            if (cci.clone_size <= cci_ref.size)
                            {
                                this.list_consclones.Add(cci);
                                // count_cons++;               // consistent clone classes
                            }
                            else
                            {
                                this.list_inconsclones.Add(cci);
                            }
                            break;
                        }
            }

        }  //==== End of refactoring class ===============
        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void software_clones_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl2.TabPages[0].Text = "";
            tabControl2.TabPages[1].Text = "";
            tabControl2.TabPages[2].Text = "";
            tabControl2.TabPages[3].Text = "";
            //tabControl2.TabPages[4].Text = "";
            richTextBox11.Text = "";
            richTextBox22.Text = "";
            richTextBox23.Text = "";
            richTextBox26.Text = "";
            richTextBox27.Text = "";
            if (cc_click == false)
            {
                List<CloneClass> cclist = new List<CloneClass>();
                List<CloneClass> fcclist = new List<CloneClass>();
                Clones obj_mcs = new Clones();
                Clones obj_mcs2 = new Clones();
                Clones obj_mcs3 = new Clones();
                DataTable outPutTableSCC = outPutTable3.Clone(); //simple clones
                DataRow dtRowt1;


                // Create a new DataSet  
                dtSett1 = new DataSet();

                // Add output table to DataSet    
                dtSett1.Tables.Add(outPutTableSCC);
                BindingSource bs3 = new BindingSource();
                bs3.DataSource = dtSett1.Tables["OutPut Table"];
                dataGridView8.DataSource = bs3;

                dataGridView8.Columns[0].Width = 40;
                dataGridView8.Columns[1].Width = 100;
                dataGridView8.Columns[2].Width = 100;

                int row_no = 1;

                // obj_mcs.take_readfile();
                obj_mcs.readfile = "clones for tool/mcc/jh7.6 mcc.txt";
                //obj_mcs.readfile = "clones for tool/scc/jh7.6.txt";

                cclist = obj_mcs.Clone_Classes();
                foreach (CloneClass cc in cclist)
                {
                    // cc.clone_id
                    dtRowt1 = outPutTableSCC.NewRow();
                    dtRowt1["No."] = row_no.ToString();
                    dtRowt1["Clone ID"] = cc.clone_id; //cc.clone_id.ToString();
                    dtRowt1["Clone Size"] = cc.clone_size; //
                    // dtRowt2["Status"] = arrnode.status; // "patern"; //cc.clone_size;
                    outPutTableSCC.Rows.Add(dtRowt1);
                    row_no++;
                }
                cloneList = new List<CloneClass>(cclist);
                ////////
                //============ scc by file =====================
                List<string> listFiles = new List<string>();
                foreach (CloneClass cc in cclist)
                {
                    foreach (cloneinstance cinst in cc.cloninstances)
                        if (listFiles.Contains(cinst.file) == false)
                            listFiles.Add(cinst.file); //unique files in clone classes
                }
                // Show in Table

                DataTable outPutTableSCCFile = fileTable.Clone(); //method clones
                DataRow dtRowt2;

                // Create a new DataSet  
                dtSett2 = new DataSet();

                // Add output table to DataSet    
                dtSett2.Tables.Add(outPutTableSCCFile);

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dtSett2.Tables["OutPut Table"];
                dataGridView3.DataSource = bs1;

                dataGridView3.Columns[0].Width = 40;
                dataGridView3.Columns[1].Width = 200;
                int scc_row_no = 1;

                foreach (string file in listFiles)
                {
                    dtRowt2 = outPutTableSCCFile.NewRow();
                    dtRowt2["File No."] = scc_row_no.ToString();
                    dtRowt2["File Name"] = file; //cc.clone_id.ToString();
                    outPutTableSCCFile.Rows.Add(dtRowt2);
                    scc_row_no++;
                }

                MCCcloneList = new List<CloneClass>(cclist);
                
                // ========= MCS with mcs id ====================
                DataTable outPutTableMCS = outPutTable3.Clone(); //mcs clones
                DataRow dtRowt3;


                // Create a new DataSet  
                dtSett3 = new DataSet();

                // Add output table to DataSet    
                dtSett3.Tables.Add(outPutTableMCS);
                BindingSource bs5 = new BindingSource();
                bs5.DataSource = dtSett3.Tables["OutPut Table"];
                dataGridView6.DataSource = bs5;

                dataGridView6.Columns[0].Width = 40;
                dataGridView6.Columns[1].Width = 100;
                dataGridView6.Columns[2].Width = 100;
                int mcs_row_no = 1;

                //obj_mcs3.take_readfile();
                obj_mcs3.readfile = "clones for tool/ms/jh7.6.txt";

                cclist = new List<CloneClass>(obj_mcs3.Clone_Classes());
               // fcclist = new List<CloneClass>(obj_mcs3.fccClasses());

                foreach (CloneClass fcc in fcclist)
                {
                    // cc.clone_id
                    dtRowt3 = outPutTableMCS.NewRow();
                    dtRowt3["No."] = mcs_row_no.ToString();
                    dtRowt3["Clone ID"] = fcc.clone_id; //cc.clone_id.ToString();
                    dtRowt3["Clone Size"] = fcc.clone_size; //
                    // dtRowt2["Status"] = arrnode.status; // "patern"; //cc.clone_size;
                    outPutTableMCS.Rows.Add(dtRowt3);
                    mcs_row_no++;
                }

                //dataGridView6.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView6.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                MCScloneList = new List<CloneClass>(fcclist);

                ////============ mcs by file =====================
                //List<string> listFccFiles = new List<string>();
                //foreach (CloneClass cc in fcclist)
                //{
                //    foreach (fccinstance cinst in cc.fccInstances)
                //        if (listFccFiles.Contains(cinst.fileName) == false)
                //            listFccFiles.Add(cinst.fileName); //unique files in clone classes
                //}
                ////listFccFilesforGen=new List<String>(listFccFiles);
                //// Show in Table

                //DataTable outPutTableFCCFile = fileTable.Clone(); //method clones
                //// DataRow dtRowt2;

                ////// Create a new DataSet  
                //dtSett4 = new DataSet();

                //// Add output table to DataSet    
                //dtSett4.Tables.Add(outPutTableFCCFile);
                //BindingSource bs6 = new BindingSource();
                //bs6.DataSource = dtSett4.Tables["OutPut Table"];
                //dataGridView11.DataSource = bs6;

                //dataGridView11.Columns[0].Width = 40;
                //dataGridView11.Columns[1].Width = 200;
                //row_no = 1;

                //foreach (string file in listFccFiles)
                //{
                //    dtRowt2 = outPutTableFCCFile.NewRow();
                //    dtRowt2["File No."] = row_no.ToString();
                //    dtRowt2["File Name"] = file; //cc.clone_id.ToString();
                //    outPutTableFCCFile.Rows.Add(dtRowt2);
                //    row_no++;
                //}
            }

                //dataGridView11.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView11.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                cc_click = true;
            
        
        }

        Refactoring ccobj1 = new Refactoring();


        private void button18_Click(object sender, EventArgs e)
        {
            tabControl4.Visible = true;
            tabControl1.Visible = false;
            tabControl3.Visible = false;
            tabControl2.TabPages[0].Text = "";
            tabControl2.TabPages[1].Text = "";
            tabControl2.TabPages[2].Text = "";
            tabControl2.TabPages[3].Text = "";
            richTextBox10.Text = "";
            richTextBox9.Text = "";
            richTextBox8.Text = "";
            richTextBox7.Text = "";
            richTextBox6.Text = "";
            richTextBox11.Text = "";
            richTextBox22.Text = "";
            richTextBox23.Text = "";
            richTextBox26.Text = "";
            richTextBox27.Text = "";

            if (ref_click == false)
            {

                List<CloneClass> cclist = new List<CloneClass>();
                DataTable outPutTableRefC = outPutTable3.Clone(); //simple clones
                DataRow dtRowt1;
                DataSet dtSetRef;
                Clones obj_clones = new Clones();
                obj_clones.readfile = "clones for tool/refactoring/label v7.5.txt";
                //obj_clones.readfile = "D:/RESEARCH/cloneevolution refactring/refactoring and clones/JhotDraw/label v7.1.txt";
                cclist = obj_clones.Clone_Classes();

                ccobj1.clones(cclist);  //read clone clases
                ccobj1.read_Refactoring();  // read refactoring file RUB
                ccobj1.mapping_refclones();  // map refactoring with clones
                ccobj1.removedClones();  // find dead clones in next version
                ccobj1.consistentclones();
                ccobj1.RefTypes();

                // Create a new DataSet  
                dtSetRef = new DataSet();
                // Add output table to DataSet    
                dtSetRef.Tables.Add(outPutTableRefC);
                BindingSource bs3 = new BindingSource();
                bs3.DataSource = dtSetRef.Tables["OutPut Table"];
                dataGridView4.DataSource = bs3;

                dataGridView4.Columns[0].Width = 40;
                dataGridView4.Columns[1].Width = 100;
                dataGridView4.Columns[2].Width = 100;

                int row_no = 1;

                foreach (CloneClass cc in ccobj1.list_refclclases)
                {
                    dtRowt1 = outPutTableRefC.NewRow();
                    dtRowt1["No."] = row_no;
                    dtRowt1["Clone ID"] = cc.clone_id;
                    dtRowt1["Clone Size"] = cc.clone_size;
                    outPutTableRefC.Rows.Add(dtRowt1);
                    row_no++;
                }
                //========== refactoring patterns ============
                DataSet dtsetRp = new DataSet();
                DataTable outPutTableRp = outPutTableRefP.Clone();
                DataRow dtRowt2;
                // Add output table to DataSet    
                dtsetRp.Tables.Add(outPutTableRp);

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dtsetRp.Tables["OutPut Table"];
                dataGridView20.DataSource = bs1;


                dataGridView20.Columns[0].Width = 60;
                dataGridView20.Columns[1].Width = 300;
                dataGridView20.Columns[2].Width = 120;

                row_no = 1;

                for (int i = 0; i < ccobj1.sl.Count - 1; i++)
                {
                    dtRowt2 = outPutTableRp.NewRow();
                    dtRowt2["No."] = row_no;
                    dtRowt2["Refactoring Patterns"] = ccobj1.sl.ElementAt(i).Key;
                    dtRowt2["Frequency"] = ccobj1.sl.Values[i];
                    outPutTableRp.Rows.Add(dtRowt2);
                    row_no++;
                }
                //====================== Removed Clones ==========
                DataTable outPutTableRC = outPutTable3.Clone();
                DataSet dtsetRC = new DataSet();
                DataRow dtRowt3;
                // Add output table to DataSet    
                dtsetRC.Tables.Add(outPutTableRC);

                BindingSource bs2 = new BindingSource();
                bs2.DataSource = dtsetRC.Tables["OutPut Table"];
                dataGridView17.DataSource = bs2;

                dataGridView17.Columns[0].Width = 40;
                dataGridView17.Columns[1].Width = 100;
                dataGridView17.Columns[2].Width = 100;

                row_no = 1;

                foreach (CloneClass cc in ccobj1.list_deadclones)
                {
                    dtRowt3 = outPutTableRC.NewRow();
                    dtRowt3["No."] = row_no;
                    dtRowt3["Clone ID"] = cc.clone_id;
                    dtRowt3["Clone Size"] = cc.clone_size;
                    outPutTableRC.Rows.Add(dtRowt3);
                    row_no++;
                }
                // =========== consistent clones ========

                DataSet dtsetCC = new DataSet();
                DataTable outPutTableCC = outPutTable3.Clone();
                DataRow dtRowt4;
                // Add output table to DataSet    
                dtsetCC.Tables.Add(outPutTableCC);

                BindingSource bsCC = new BindingSource();
                bsCC.DataSource = dtsetCC.Tables["OutPut Table"];
                dataGridView19.DataSource = bsCC;

                dataGridView19.Columns[0].Width = 40;
                dataGridView19.Columns[1].Width = 100;
                dataGridView19.Columns[2].Width = 100;

                row_no = 1;
                foreach (CloneClass cc in ccobj1.list_consclones)
                {
                    dtRowt4 = outPutTableCC.NewRow();
                    dtRowt4["No."] = row_no;
                    dtRowt4["Clone ID"] = cc.clone_id;
                    dtRowt4["Clone Size"] = cc.clone_size;
                    outPutTableCC.Rows.Add(dtRowt4);
                    row_no++;
                }
            }
            ref_click = true;

        }
    }
}
