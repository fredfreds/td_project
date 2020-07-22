using UnityEngine;

namespace TDProject
{
    public class RaycastManager : UpdateBehavior
    {
        // используем для установки таверов
        public override void DoUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosFar = new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y, Camera.main.farClipPlane);

                Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y, Camera.main.nearClipPlane);

                Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
                Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

                RaycastHit hit;

                if (Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit))
                {
                    if (hit.transform.name == "Tower")
                    {
                        TowerController towerController = hit.transform.GetComponent<TowerController>();
                        if (towerController.CanPlace)
                        {
                            towerController.PlaceTower(hit.transform.position);
                            towerController.CanPlace = false;
                        }
                    }
                }
            }

        }
    }
}