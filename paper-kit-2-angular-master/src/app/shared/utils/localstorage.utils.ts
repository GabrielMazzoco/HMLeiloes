export class LocalStorageUtils {
    public static push(key: string, value: any) {
        localStorage.setItem(key, JSON.stringify(value));
    }
    public static get(key: string) {
        const item = localStorage.getItem(key);
        return JSON.parse(item);
    }

    public static clear(key: string) {
        localStorage.removeItem(key);
    }

    public static hasKey(key: string) {
        const obj = localStorage.getItem(key);
        return obj;
    }
}
