﻿using MSPowerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPowerWebApp.Common
{
    public class MessageStore
    {
        public static FixedSizeGenericHashTable<string, FriendlyMessageInfo> hash = new FixedSizeGenericHashTable<string, FriendlyMessageInfo>(400);

        static MessageStore()
        {
            #region System

            FriendlyMessageInfo SYS01 = new FriendlyMessageInfo("SYS01", MessageType.Danger, "We are currently unable to process your request, Please try again later or contact system administrator.");
            hash.Add("SYS01", SYS01);

            FriendlyMessageInfo SYS02 = new FriendlyMessageInfo("SYS02", MessageType.Info, "Your session has expired. Please login again.");
            hash.Add("SYS02", SYS02);

            FriendlyMessageInfo SYS03 = new FriendlyMessageInfo("SYS03", MessageType.Danger, "Invalid login credentials. Please login with valid username & password.");
            hash.Add("SYS03", SYS03);

            FriendlyMessageInfo SYS04 = new FriendlyMessageInfo("SYS04", MessageType.Info, "No records found.");
            hash.Add("SYS04", SYS04);

            FriendlyMessageInfo SYS05 = new FriendlyMessageInfo("SYS05", MessageType.Info, "Password has been changed successfully.");
            hash.Add("SYS05", SYS05);

            FriendlyMessageInfo SYS06 = new FriendlyMessageInfo("SYS06", MessageType.Danger, "You dont have online access. Please contact administrator.");
            hash.Add("SYS06", SYS06);

            #endregion

            #region Product Details

            FriendlyMessageInfo PD001 = new FriendlyMessageInfo("PD001", MessageType.Success, "Product details saved successfully.");
            hash.Add("PD001", PD001);

            FriendlyMessageInfo PD002 = new FriendlyMessageInfo("PD002", MessageType.Success, "Product details updated successfully.");
            hash.Add("PD002", PD002);

            #endregion

            #region Product 

            FriendlyMessageInfo P001 = new FriendlyMessageInfo("P001", MessageType.Success, "Product saved successfully.");
            hash.Add("P001", P001);

            FriendlyMessageInfo P002 = new FriendlyMessageInfo("P002", MessageType.Success, "Product updated successfully.");
            hash.Add("P002", P002);

            #endregion

            #region Service

            FriendlyMessageInfo S001 = new FriendlyMessageInfo("S001", MessageType.Success, "Service saved successfully.");
            hash.Add("S001", S001);

            FriendlyMessageInfo S002 = new FriendlyMessageInfo("S002", MessageType.Success, "Service updated successfully.");
            hash.Add("S002", S002);

            #endregion

            #region News Letter

            FriendlyMessageInfo N001 = new FriendlyMessageInfo("N001", MessageType.Success, "News letter saved successfully.");
            hash.Add("N001", N001);

            FriendlyMessageInfo N002 = new FriendlyMessageInfo("N002", MessageType.Success, "News letter updated successfully.");
            hash.Add("N002", N002);

            #endregion

            #region About us

            FriendlyMessageInfo A001 = new FriendlyMessageInfo("A001", MessageType.Success, "About us saved successfully.");
            hash.Add("A001", A001);

            FriendlyMessageInfo A002 = new FriendlyMessageInfo("A002", MessageType.Success, "About us updated successfully.");
            hash.Add("A002", A002);

            #endregion

            #region Contact us

            FriendlyMessageInfo C001 = new FriendlyMessageInfo("C001", MessageType.Success, "Contact us saved successfully.");
            hash.Add("C001", C001);

            FriendlyMessageInfo C002 = new FriendlyMessageInfo("C002", MessageType.Success, "Contact us updated successfully.");
            hash.Add("C002", C002);

            #endregion

            #region Events

            FriendlyMessageInfo E001 = new FriendlyMessageInfo("E001", MessageType.Success, "Events saved successfully.");
            hash.Add("E001", E001);

            FriendlyMessageInfo E002 = new FriendlyMessageInfo("E002", MessageType.Success, "Events updated successfully.");
            hash.Add("E002", E002);

            #endregion

            #region Job Opening

            FriendlyMessageInfo JB001 = new FriendlyMessageInfo("JB001", MessageType.Success, "Job opening saved successfully.");
            hash.Add("JB001", JB001);

            FriendlyMessageInfo JB002 = new FriendlyMessageInfo("JB002", MessageType.Success, "Job opening updated successfully.");
            hash.Add("JB002", JB002);

            #endregion

            #region Image Upload

            FriendlyMessageInfo IU001 = new FriendlyMessageInfo("IU001", MessageType.Success, "File was uploaded successfully.");
            hash.Add("IU001", IU001);

            FriendlyMessageInfo IU002 = new FriendlyMessageInfo("IU002", MessageType.Warning, "No File was specified for upload.");
            hash.Add("IU002", IU002);

            FriendlyMessageInfo IU003 = new FriendlyMessageInfo("IU003", MessageType.Warning, "Files with Jpeg, Jpg, Png are allowed for uploads");
            hash.Add("IU003", IU003);


            #endregion
        }

        public static FriendlyMessageInfo Get(string code)
        {
            FriendlyMessageInfo message = hash.Find(code);

            return message;
        }

        /// <summary>
        /// struct to hold generic key and value
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks></remarks>
        public struct KeyValue<K, V>
        {
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            /// <remarks></remarks>
            public K Key { get; set; }
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            /// <remarks></remarks>
            public V Value { get; set; }
        }

        /// <summary>
        /// FixedSizeGenericHashTable
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks>Object for FixedSizeGenericHashTable of key K and of value V</remarks>
        /// 
        public class FixedSizeGenericHashTable<K, V>
        {
            private readonly int size;
            private readonly LinkedList<KeyValue<K, V>>[] items;

            public FixedSizeGenericHashTable(int size)
            {
                this.size = size;
                items = new LinkedList<KeyValue<K, V>>[size];
            }

            protected int GetArrayPosition(K key)
            {
                int position = key.GetHashCode() % size;
                return Math.Abs(position);
            }

            public V Find(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                return default(V);
            }

            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            /// <remarks></remarks>
            public void Add(K key, V value)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
                linkedList.AddLast(item);
            }

            /// <summary>
            /// Removes the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <remarks></remarks>
            public void Remove(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        foundItem = item;
                    }
                }

                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }

            /// <summary>
            /// Gets the linked list.
            /// </summary>
            /// <param name="position">The position.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            /// 
            protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedList = items[position];

                if (linkedList == null)
                {
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }

                return linkedList;
            }
        }
    }
}