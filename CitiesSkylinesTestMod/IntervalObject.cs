using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace CitiesSkylinesTestMod
{
    public class IntervalObject : MonoBehaviour
    {

        bool cycle = false;

        System.Random rnd = new System.Random();

        // numbers to store
        public int blocks_created = 0;
        public int blocks_unzoned = 0;
        public int blocks_residential = 0;

        public void fetchNumbers()
        {
            ref ZoneBlock[] blocks = ref ZoneManager.instance.m_blocks.m_buffer;
            int _created = 0;
            int _residential = 0;
            int _unzoned = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                // you need a reference here
                ref var block = ref blocks[i];
                if ((block.m_flags & ZoneBlock.FLAG_CREATED) != 0)
                {
                    int rows = block.RowCount;
                    for (int x = 0; x < ZoneBlock.COLUMN_COUNT; x++)
                    {
                        for (int z = 0; z < rows; z++)
                        {
                            ulong mask = (ulong)(1L << ((z << 3) | x));
                            if ((block.m_valid & mask) != 0 && (block.m_shared) == 0)
                            {
                                _created++;
                                ItemClass.Zone zone = block.GetZone(x, z);
                                switch (zone)
                                {
                                    case ItemClass.Zone.ResidentialLow:
                                        _residential++;
                                        break;
                                    case ItemClass.Zone.Unzoned:
                                        _unzoned++;
                                        break;
                                }

                                if (rnd.NextDouble() < 0.5)
                                {
                                    if (rnd.NextDouble() < 0.5)
                                    {
                                        block.SetZone(x, z, ItemClass.Zone.ResidentialLow);
                                    }
                                    else
                                    {
                                        block.SetZone(x, z, ItemClass.Zone.Unzoned);
                                    }
                                }

                            }
                        }
                    }
                    block.RefreshZoning((ushort)i);
                }
            }
            blocks_created = _created;
            blocks_residential = _residential;
            blocks_unzoned = _unzoned;
        }

        public void Start()
        {
            Debug.Log("Interval Object Started");
        }

        public void Update()
        {
            if (!cycle)
            {
                cycle = true;
                StartCoroutine(interval());
            }
        }

        public IEnumerator interval()
        {
            Debug.Log("--Iteration--");

            fetchNumbers();

            Debug.Log("created: " + blocks_created);
            Debug.Log("residential: " + blocks_residential);
            Debug.Log("unzoned: " + blocks_unzoned);

            yield return new WaitForSeconds(5);
            cycle = false;
        }

    }
}
