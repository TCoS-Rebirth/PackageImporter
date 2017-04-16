using System;
using System.Collections.Generic;

namespace TCosReborn.Framework.Utility
{
    public class IDTracker
    {
        readonly HashSet<int> allocatedIDs = new HashSet<int> { 0 };

        public int AllocateID()
        {
            var id = 0;
            while (allocatedIDs.Contains(id))
            {
                id += 1;
            }
            allocatedIDs.Add(id);
            return id;
        }

        public void ReleaseID(int id)
        {
            allocatedIDs.Remove(id);
        }

        public bool SetIDAllocated(int id)
        {
            if (!allocatedIDs.Contains(id))
            {
                allocatedIDs.Add(id);
                return true;
            }
            throw new Exception("ID collision, this should not happen");
        }

        public void Reset()
        {
            allocatedIDs.Clear();
        }
    }
}