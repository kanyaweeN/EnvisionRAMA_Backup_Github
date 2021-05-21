import { SubMenuInfo } from "./submenu-info";

export class MenuInfo {
    label: string;
    icon: string;
    routerLink: string[] = [];
    items: SubMenuInfo[] = [];
}