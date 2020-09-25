namespace DiscriminatedUnions
{
    public class Union<A, B>
    {
        public static implicit operator Union<A, B>(A value) => new Union<A, B>(value);
        public static implicit operator Union<A, B>(B value) => new Union<A, B>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C>
    {
        public static implicit operator Union<A, B, C>(A value) => new Union<A, B, C>(value);
        public static implicit operator Union<A, B, C>(B value) => new Union<A, B, C>(value);
        public static implicit operator Union<A, B, C>(C value) => new Union<A, B, C>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D>
    {
        public static implicit operator Union<A, B, C, D>(A value) => new Union<A, B, C, D>(value);
        public static implicit operator Union<A, B, C, D>(B value) => new Union<A, B, C, D>(value);
        public static implicit operator Union<A, B, C, D>(C value) => new Union<A, B, C, D>(value);
        public static implicit operator Union<A, B, C, D>(D value) => new Union<A, B, C, D>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E>
    {
        public static implicit operator Union<A, B, C, D, E>(A value) => new Union<A, B, C, D, E>(value);
        public static implicit operator Union<A, B, C, D, E>(B value) => new Union<A, B, C, D, E>(value);
        public static implicit operator Union<A, B, C, D, E>(C value) => new Union<A, B, C, D, E>(value);
        public static implicit operator Union<A, B, C, D, E>(D value) => new Union<A, B, C, D, E>(value);
        public static implicit operator Union<A, B, C, D, E>(E value) => new Union<A, B, C, D, E>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F>
    {
        public static implicit operator Union<A, B, C, D, E, F>(A value) => new Union<A, B, C, D, E, F>(value);
        public static implicit operator Union<A, B, C, D, E, F>(B value) => new Union<A, B, C, D, E, F>(value);
        public static implicit operator Union<A, B, C, D, E, F>(C value) => new Union<A, B, C, D, E, F>(value);
        public static implicit operator Union<A, B, C, D, E, F>(D value) => new Union<A, B, C, D, E, F>(value);
        public static implicit operator Union<A, B, C, D, E, F>(E value) => new Union<A, B, C, D, E, F>(value);
        public static implicit operator Union<A, B, C, D, E, F>(F value) => new Union<A, B, C, D, E, F>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G>
    {
        public static implicit operator Union<A, B, C, D, E, F, G>(A value) => new Union<A, B, C, D, E, F, G>(value);
        public static implicit operator Union<A, B, C, D, E, F, G>(B value) => new Union<A, B, C, D, E, F, G>(value);
        public static implicit operator Union<A, B, C, D, E, F, G>(C value) => new Union<A, B, C, D, E, F, G>(value);
        public static implicit operator Union<A, B, C, D, E, F, G>(D value) => new Union<A, B, C, D, E, F, G>(value);
        public static implicit operator Union<A, B, C, D, E, F, G>(E value) => new Union<A, B, C, D, E, F, G>(value);
        public static implicit operator Union<A, B, C, D, E, F, G>(F value) => new Union<A, B, C, D, E, F, G>(value);
        public static implicit operator Union<A, B, C, D, E, F, G>(G value) => new Union<A, B, C, D, E, F, G>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G, H>
    {
        public static implicit operator Union<A, B, C, D, E, F, G, H>(A value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(B value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(C value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(D value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(E value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(F value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(G value) => new Union<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H>(H value) => new Union<A, B, C, D, E, F, G, H>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }
        public Union(H item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G, H, I>
    {
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(A value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(B value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(C value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(D value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(E value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(F value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(G value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(H value) => new Union<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I>(I value) => new Union<A, B, C, D, E, F, G, H, I>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }
        public Union(H item) { Item = item; }
        public Union(I item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G, H, I, J>
    {
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(A value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(B value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(C value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(D value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(E value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(F value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(G value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(H value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(I value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J>(J value) => new Union<A, B, C, D, E, F, G, H, I, J>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }
        public Union(H item) { Item = item; }
        public Union(I item) { Item = item; }
        public Union(J item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G, H, I, J, K>
    {
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(A value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(B value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(C value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(D value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(E value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(F value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(G value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(H value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(I value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(J value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K>(K value) => new Union<A, B, C, D, E, F, G, H, I, J, K>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }
        public Union(H item) { Item = item; }
        public Union(I item) { Item = item; }
        public Union(J item) { Item = item; }
        public Union(K item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G, H, I, J, K, L>
    {
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(A value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(B value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(C value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(D value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(E value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(F value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(G value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(H value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(I value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(J value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(K value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L>(L value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }
        public Union(H item) { Item = item; }
        public Union(I item) { Item = item; }
        public Union(J item) { Item = item; }
        public Union(K item) { Item = item; }
        public Union(L item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Union<A, B, C, D, E, F, G, H, I, J, K, L, M>
    {
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(A value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(B value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(C value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(D value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(E value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(F value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(G value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(H value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(I value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(J value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(K value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(L value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(M value) => new Union<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);

        public Union(A item) { Item = item; }
        public Union(B item) { Item = item; }
        public Union(C item) { Item = item; }
        public Union(D item) { Item = item; }
        public Union(E item) { Item = item; }
        public Union(F item) { Item = item; }
        public Union(G item) { Item = item; }
        public Union(H item) { Item = item; }
        public Union(I item) { Item = item; }
        public Union(J item) { Item = item; }
        public Union(K item) { Item = item; }
        public Union(L item) { Item = item; }
        public Union(M item) { Item = item; }

        public dynamic Item { get; }
    }
}
