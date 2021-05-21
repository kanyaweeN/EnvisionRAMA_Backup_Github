import { MenuInfo } from "./menu-info";

export class UserInfo {
    public Id: number;
    public DisplayName: string;
    public FName: string;
    public MName: string;
    public LName: string;
    public Token: string;

    public OrgId: number;
    public OrgName: string;

    public UserMenu: MenuInfo[] = [];
    public Themes: string;
    public MenuLayout: string;
    public ProfileLayout: string;

    public IsLayoutCompact: boolean;
    public IsDaskMenu: boolean;
}