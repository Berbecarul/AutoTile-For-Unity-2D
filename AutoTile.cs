using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
#endif


namespace MyAutoTile
{
    [CreateAssetMenu(fileName = "NewAutoTile", menuName = "AutoTile", order = 1)]
    public class AutoTile : TileBase
    {

        public Color color;
        public Tile.ColliderType colliderType;

         
        [HideInInspector]
        public List<Sprite> autoTiles;

 


        public override void RefreshTile(Vector3Int location, ITilemap tileMap)
        {
           
            for (int yd = -1; yd <= 1; yd++)
                for (int xd = -1; xd <= 1; xd++)
                { 
                    Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                    if (TileExists(tileMap, position))
                        tileMap.RefreshTile(position);
                }
        }

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {

            tileData.color = color;
            tileData.colliderType = colliderType;
            tileData.transform = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 0f), Vector3.one);
            tileData.flags = TileFlags.LockTransform | TileFlags.LockColor;

            

            tileData.sprite = SelectAutoSprite(GetRawTileType(position, tilemap));


        }




        private bool TileExists(ITilemap tileMap, Vector3Int position)
        {
            TileBase tile = tileMap.GetTile(position);
            return (tile != null);
        }


        int GetRawTileType(Vector3Int position, ITilemap tilemap)
        {
            bool up, down, left, right;
            bool upRight, upLeft, downRight, downLeft;

            up = TileExists(tilemap, position + Vector3Int.up);
            down = TileExists(tilemap, position + Vector3Int.down);
            left = TileExists(tilemap, position + Vector3Int.left);
            right = TileExists(tilemap, position + Vector3Int.right);

            upRight = TileExists(tilemap, position + Vector3Int.right + Vector3Int.up);
            upLeft = TileExists(tilemap, position + Vector3Int.left + Vector3Int.up);
            downRight = TileExists(tilemap, position + Vector3Int.right + Vector3Int.down);
            downLeft = TileExists(tilemap, position + Vector3Int.left + Vector3Int.down);


            if (up && left && down && right && upRight && upLeft && downRight && downLeft)
                return 7;

            if (up && left && down && right && !downRight && upLeft && upRight && downLeft)
                return 16;

            if (up && left && down && right && !downLeft && upLeft && upRight && downRight)
                return 17;

            if (up && left && down && right && !upRight && upLeft && downLeft && downRight)
                return 22;

            if (up && left && down && right && !upLeft && upRight && downLeft && downRight)
                return 23;

            if (up && left && down && right && upLeft && !upRight && downLeft && !downRight)
                return 26;

            if (up && left && down && right && upLeft && upRight && !downLeft && !downRight)
                return 27;

            if (up && left && down && right && !upLeft && !upRight && downLeft && !downRight)
                return 28;

            if (up && left && down && right && upLeft && !upRight && !downLeft && !downRight)
                return 29;

            if (up && left && down && right && !upLeft && !upRight && downLeft && downRight)
                return 32;

            if (up && left && down && right && !upLeft && upRight && !downLeft && downRight)
                return 33;

            if (up && left && down && right && !upLeft && !upRight && !downLeft && downRight)
                return 34;

            if (up && left && down && right && !upLeft && upRight && !downLeft && !downRight)
                return 35;

            if (up && left && down && right && !upLeft && !upRight && !downLeft && !downRight)
                return 40;

            if (up && left && down && right && upLeft && !upRight && !downLeft && downRight)
                return 41;

            if (up && left && down && right && !upLeft && upRight && downLeft && !downRight)
                return 46;

            if (up && !left && down && right && !upRight && !downRight)
                return 24;

            if (!up && left && down && right && !downLeft && !downRight)
                return 25;

            if (up && left && !down && right && !upLeft && !upRight)
                return 30;

            if (up && left && down && !right && !upLeft && !downLeft)
                return 31;

            if (up && !left && down && right && upRight && !downRight)
                return 36;

            if (!up && left && down && right && !downLeft && downRight)
                return 37;

            if (!up && left && down && right && downLeft && !downRight)
                return 38;

            if (up && left && down && !right && upLeft && !downLeft)
                return 39;

            if (up && left && !down && right && upLeft && !upRight)
                return 42;

            if (up && left && down && !right && !upLeft && downLeft)
                return 43;

            if (up && !left && down && right && !upRight && downRight)
                return 44;

            if (up && left && !down && right && !upLeft && upRight)
                return 45;

            if (!up && !left && down && right && !downRight)
                return 4;

            if (!up && left && down && !right && !downLeft)
                return 5;

            if (up && !left && !down && right && !upRight)
                return 10;

            if (up && left && !down && !right && !upLeft)
                return 11;

            if (up && !left && !down && right && upRight)
                return 12;

            if (up && left && !down && !right && upLeft)
                return 14;

            if (!up && left && down && !right && downLeft)
                return 2;

            if (!up && !left && down && right && downRight)
                return 0;

            if (!up && !left && !down && right)
                return 18;

            if (!up && left && !down && right)
                return 19;

            if (!up && left && !down && !right)
                return 20;

            if (!up && !left && !down && !right)
                return 21;

            if (up && left && !down && right)
                return 13;

            if (up && !left && !down && !right)
                return 15;

            if (!up && left && down && right)
                return 1;

            if (!up && !left && down && !right)
                return 3;

            if (up && !left && down && right)
                return 6;

            if (up && left && down && !right)
                return 8;

            if (up && !left && down && !right)
                return 9;

            return 47;
        }


        Sprite SelectAutoSprite(int spriteType)
        {
            switch (spriteType)
            {
                case 0: return autoTiles[spriteType]; 
                case 1: return autoTiles[spriteType];
                case 2: return autoTiles[spriteType];
                case 3: return autoTiles[spriteType];
                case 4: return autoTiles[spriteType] ?? autoTiles[0];
                case 5: return autoTiles[spriteType] ?? autoTiles[2];
                case 6: return autoTiles[spriteType];
                case 7: return autoTiles[spriteType];
                case 8: return autoTiles[spriteType];
                case 9: return autoTiles[spriteType];
                case 10: return autoTiles[spriteType] ?? autoTiles[12];
                case 11: return autoTiles[spriteType] ?? autoTiles[14];
                case 12: return autoTiles[spriteType];
                case 13: return autoTiles[spriteType];
                case 14: return autoTiles[spriteType];
                case 15: return autoTiles[spriteType];
                case 16: return autoTiles[spriteType] ?? autoTiles[7];
                case 17: return autoTiles[spriteType] ?? autoTiles[7];
                case 18: return autoTiles[spriteType];
                case 19: return autoTiles[spriteType];
                case 20: return autoTiles[spriteType];
                case 21: return autoTiles[spriteType];
                case 22: return autoTiles[spriteType] ?? autoTiles[7];
                case 23: return autoTiles[spriteType] ?? autoTiles[7];
                case 24: return autoTiles[spriteType] ?? autoTiles[6];
                case 25: return autoTiles[spriteType] ?? autoTiles[1];
                case 26: return autoTiles[spriteType] ?? autoTiles[7];
                case 27: return autoTiles[spriteType] ?? autoTiles[7];
                case 28: return autoTiles[spriteType] ?? autoTiles[7];
                case 29: return autoTiles[spriteType] ?? autoTiles[7];
                case 30: return autoTiles[spriteType] ?? autoTiles[13];
                case 31: return autoTiles[spriteType] ?? autoTiles[8];
                case 32: return autoTiles[spriteType] ?? autoTiles[7];
                case 33: return autoTiles[spriteType] ?? autoTiles[7];
                case 34: return autoTiles[spriteType] ?? autoTiles[7];
                case 35: return autoTiles[spriteType] ?? autoTiles[7];
                case 36: return autoTiles[spriteType] ?? autoTiles[6];
                case 37: return autoTiles[spriteType] ?? autoTiles[1];
                case 38: return autoTiles[spriteType] ?? autoTiles[1];
                case 39: return autoTiles[spriteType] ?? autoTiles[8];
                case 40: return autoTiles[spriteType] ?? autoTiles[7];
                case 41: return autoTiles[spriteType] ?? autoTiles[7];
                case 42: return autoTiles[spriteType] ?? autoTiles[13];
                case 43: return autoTiles[spriteType] ?? autoTiles[8];
                case 44: return autoTiles[spriteType] ?? autoTiles[6];
                case 45: return autoTiles[spriteType] ?? autoTiles[13];
                case 46: return autoTiles[spriteType] ?? autoTiles[7];
                case 47: return autoTiles[spriteType];





                default:
                    break;
            }





            return autoTiles[47];
        }



    }


#if UNITY_EDITOR



    [CustomEditor(typeof(AutoTile))]
    public class AutoTileEditor : Editor
    {
        private AutoTile _autoTile { get { return (target as AutoTile); } }
      
        bool showTiles = false;
        

        int[] mustHaveTiles = { 0, 1, 2, 3, 6, 7, 8, 9, 12, 13, 14, 15, 18, 19, 20, 21 };

        public void OnEnable()
        {

            if (_autoTile.autoTiles == null)
            {
                _autoTile.autoTiles = new List<Sprite>();
                for (int i = 0; i < 48; i++)
                {
                    _autoTile.autoTiles.Add(null);
                }
            }

        }


        public override void OnInspectorGUI()
        {


            EditorGUI.BeginChangeCheck();

            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Place sprites based on sprite type");


            showTiles = EditorGUILayout.Foldout(showTiles, "Auto Tiles");
            if (showTiles)
            {
                for (int i = 0; i < 47; i++)

                    if (mustHaveTiles.Contains(i)) 
                        _autoTile.autoTiles[i] =
                        (Sprite)EditorGUILayout.ObjectField(
                            i.ToString() + " _MUST_HAVE_", _autoTile.autoTiles[i], typeof(Sprite), false, null);
                else
                        _autoTile.autoTiles[i] =
                       (Sprite)EditorGUILayout.ObjectField(i.ToString(), _autoTile.autoTiles[i], typeof(Sprite), false, null);
            }

           


            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_autoTile);
        }
    }
#endif











}