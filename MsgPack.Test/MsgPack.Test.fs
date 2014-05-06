﻿namespace MsgPack.Test

open NUnit.Framework
open MsgPack

module TestExtensions =

    let assertEqualTo<'a> (expected: 'a) (actual: 'a) = Assert.That(actual, Is.EqualTo(expected))
    let assertEquivalentTo<'a> expected (actual: 'a) = Assert.That(actual, Is.EquivalentTo(expected))

open TestExtensions

[<TestFixture>]
module PackBoolTest =
    [<Test>]
    let ``Given true Then return 0xC3``() =
        true |> Packer.packBool |> assertEquivalentTo [| 0xC3uy |]

    [<Test>]
    let ``Given false Then return 0xC2``() =
        false |> Packer.packBool |> assertEquivalentTo [| 0xC2uy |]

[<TestFixture>]
module PackByteTest =
    [<Test>]
    let ``Given 127 Then return 0x7F``() =
        127uy |> Packer.packByte |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given 128 Then return 0xCC80``() =
        128uy |> Packer.packByte |> assertEquivalentTo [| 0xCCuy; 0x80uy |]
        
    [<Test>]
    let ``Given 255 Then return 0xCDFF``() =
        255uy |> Packer.packByte |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

[<TestFixture>]
module PackUInt16Test =
    [<Test>]
    let ``Given 127 Then return 0x7F``() =
        127us |> Packer.packUInt16 |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given 128 Then return 0xCC80``() =
        128us |> Packer.packUInt16 |> assertEquivalentTo [| 0xCCuy; 0x80uy |]
        
    [<Test>]
    let ``Given 255 Then return 0xCCFF``() =
        255us |> Packer.packUInt16 |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

    [<Test>]
    let ``Given 256 Then return 0xCD0100``() =
        256us |> Packer.packUInt16 |> assertEquivalentTo [| 0xCDuy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 65535 Then return 0xCDFFFF``() =
        65535us |> Packer.packUInt16 |> assertEquivalentTo [| 0xCDuy; 0xFFuy; 0xFFuy |]

[<TestFixture>]
module PackUInt32Test =
    [<Test>]
    let ``Given 127 Then return 0x7F``() =
        127u |> Packer.packUInt32 |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given 128 Then return 0xCC80``() =
        128u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCCuy; 0x80uy |]
        
    [<Test>]
    let ``Given 255 Then return 0xCCFF``() =
        255u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

    [<Test>]
    let ``Given 256 Then return 0xCD0100``() =
        256u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCDuy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 65535 Then return 0xCDFFFF``() =
        65535u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCDuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 65536 Then return 0xCE00010000``() =
        65536u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCEuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 4294967295 Then return 0xCEFFFFFFFF``() =
        4294967295u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCEuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 0x12345678 Then return 0xCE12345678``() =
        0x12345678u |> Packer.packUInt32 |> assertEquivalentTo [| 0xCEuy; 0x12uy; 0x34uy; 0x56uy; 0x78uy |]

[<TestFixture>]
module PackUInt64Test =
    [<Test>]
    let ``Given 128 Then return 0xCC80``() =
        128UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCCuy; 0x80uy |]
        
    [<Test>]
    let ``Given 255 Then return 0xCCFF``() =
        255UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

    [<Test>]
    let ``Given 256 Then return 0xCD0100``() =
        256UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCDuy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 65535 Then return 0xCDFFFF``() =
        65535UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCDuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 65536 Then return 0xCE010000``() =
        65536UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCEuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 4294967295 Then return 0xCEFFFFFFFF``() =
        4294967295UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCEuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 4294967296 Then return 0xCF0000000100000000``() =
        4294967296UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCFuy; 0x00uy; 0x00uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 18446744073709551615 Then return 0xCFFFFFFFFFFFFFFFFF``() =
         18446744073709551615UL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 0x0123456789ABCDEF Then return 0xCE0123456789ABCDEF``() =
        0x0123456789ABCDEFUL |> Packer.packUInt64 |> assertEquivalentTo [| 0xCFuy; 0x01uy; 0x23uy; 0x45uy; 0x67uy; 0x89uy; 0xABuy; 0xCDuy; 0xEFuy |]

[<TestFixture>]
module PackSByteTest =
    [<Test>]
    let ``Given 127 Then return 0x7F`` () =
        127y |> Packer.packSByte |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given -32 Then return 0xE0`` () =
        -32y |> Packer.packSByte |> assertEquivalentTo [| 0xE0uy |]

    [<Test>]
    let ``Given -33 Then return 0xD0DF`` () =
        -33y |> Packer.packSByte |> assertEquivalentTo [| 0xD0uy; 0xDFuy |]

    [<Test>]
    let ``Given -128 Then return 0xD080`` () =
        -128y |> Packer.packSByte |> assertEquivalentTo [| 0xD0uy; 0x80uy |]

[<TestFixture>]
module PackInt16Test =
    [<Test>]
    let ``Given 32767 Then return 0xCD7FFF`` () =
        32767s |> Packer.packInt16 |> assertEquivalentTo [| 0xCDuy; 0x7Fuy; 0xFFuy |]

    [<Test>]
    let ``Given 256 Then return 0xCD0100`` () =
        256s |> Packer.packInt16 |> assertEquivalentTo [| 0xCDuy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 255 Then return 0xCCFF`` () =
        255s |> Packer.packInt16 |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

    [<Test>]
    let ``Given 128 Then return 0xCC80`` () =
        128s |> Packer.packInt16 |> assertEquivalentTo [| 0xCCuy; 0x80uy |]

    [<Test>]
    let ``Given 127 Then return 0x7F`` () =
        127s |> Packer.packInt16 |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given -32 Then return 0xE0`` () =
        -32s |> Packer.packInt16 |> assertEquivalentTo [| 0xE0uy |]

    [<Test>]
    let ``Given -33 Then return 0xD0DF`` () =
        -33s |> Packer.packInt16 |> assertEquivalentTo [| 0xD0uy; 0xDFuy |]

    [<Test>]
    let ``Given -128 Then return 0xD080`` () =
        -128s |> Packer.packInt16 |> assertEquivalentTo [| 0xD0uy; 0x80uy |]

    [<Test>]
    let ``Given -129 Then return 0xD1FF7F`` () =
        -129s |> Packer.packInt16 |> assertEquivalentTo [| 0xD1uy; 0xFFuy; 0x7Fuy |]

    [<Test>]
    let ``Given -32768 Then return 0xD18000`` () =
        -32768s |> Packer.packInt16 |> assertEquivalentTo [| 0xD1uy; 0x80uy; 0x00uy |]

[<TestFixture>]
module PackIntTest = 
    [<Test>]
    let ``Given 2147483647 Then return 0xCE7FFFFFFF``() =
        2147483647 |> Packer.packInt |> assertEquivalentTo [| 0xCEuy; 0x7Fuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 65536 Then return 0xCE00010000``() =
        65536 |> Packer.packInt |> assertEquivalentTo [| 0xCEuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 65535 Then return 0xCDFFFF``() =
        65535 |> Packer.packInt |> assertEquivalentTo [| 0xCDuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 256 Then return 0xCD0100``() =
        256 |> Packer.packInt |> assertEquivalentTo [| 0xCDuy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 255 Then return 0xCCFF``() =
        255 |> Packer.packInt |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

    [<Test>]
    let ``Given 128 Then return 0xCC80``() =
        128 |> Packer.packInt |> assertEquivalentTo [| 0xCCuy; 0x80uy |]

    [<Test>]
    let ``Given 127 Then return 0x7F``() =
        127 |> Packer.packInt |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given -32 Then return 0xE0``() =
        -32 |> Packer.packInt |> assertEquivalentTo [| 0xE0uy |]

    [<Test>]
    let ``Given -33 Then return 0xD0DF``() =
        -33 |> Packer.packInt |> assertEquivalentTo [| 0xD0uy; 0xDFuy |]

    [<Test>]
    let ``Given -128 Then return 0xD080``() =
        -128 |> Packer.packInt |> assertEquivalentTo [| 0xD0uy; 0x80uy |]

    [<Test>]
    let ``Given -129 Then return 0xD1FF7F``() =
        -129 |> Packer.packInt |> assertEquivalentTo [| 0xD1uy; 0xFFuy; 0x7Fuy |]

    [<Test>]
    let ``Given -32768 Then return 0xD18000``() =
        -32768 |> Packer.packInt |> assertEquivalentTo [| 0xD1uy; 0x80uy; 0x00uy |]

    [<Test>]
    let ``Given -32769 Then return 0xD2FFFF7FFF``() =
        -32769 |> Packer.packInt |> assertEquivalentTo [| 0xD2uy; 0xFFuy; 0xFFuy; 0x7Fuy; 0xFFuy |]

    [<Test>]
    let ``Given -2147483648 Then return 0xD280000000``() =
        -2147483648 |> Packer.packInt |> assertEquivalentTo [| 0xD2uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module PackInt64Test =
    [<Test>]
    let ``Given 9223372036854775807 Then return 0xCF7FFFFFFFFFFFFFFF``() =
        9223372036854775807L |> Packer.packInt64 |> assertEquivalentTo [| 0xCFuy; 0x7Fuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 4294967296L Then return 0xCF0000000100000000``() =
        4294967296L |> Packer.packInt64 |> assertEquivalentTo [| 0xCFuy; 0x00uy; 0x00uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 4294967295 Then return 0xCE7FFFFFFF``() =
        4294967295L |> Packer.packInt64 |> assertEquivalentTo [| 0xCEuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 65536 Then return 0xCE00010000``() =
        65536L |> Packer.packInt64 |> assertEquivalentTo [| 0xCEuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 65535 Then return 0xCDFFFF``() =
        65535L |> Packer.packInt64 |> assertEquivalentTo [| 0xCDuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 256 Then return 0xCD0100``() =
        256L |> Packer.packInt64 |> assertEquivalentTo [| 0xCDuy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 255 Then return 0xCCFF``() =
        255L |> Packer.packInt64 |> assertEquivalentTo [| 0xCCuy; 0xFFuy |]

    [<Test>]
    let ``Given 128 Then return 0xCC80``() =
        128L |> Packer.packInt64 |> assertEquivalentTo [| 0xCCuy; 0x80uy |]

    [<Test>]
    let ``Given 127 Then return 0x7F``() =
        127L |> Packer.packInt64 |> assertEquivalentTo [| 0x7Fuy |]

    [<Test>]
    let ``Given -32 Then return 0xE0``() =
        -32L |> Packer.packInt64 |> assertEquivalentTo [| 0xE0uy |]

    [<Test>]
    let ``Given -33 Then return 0xD0DF``() =
        -33L |> Packer.packInt64 |> assertEquivalentTo [| 0xD0uy; 0xDFuy |]

    [<Test>]
    let ``Given -128 Then return 0xD080``() =
        -128L |> Packer.packInt64 |> assertEquivalentTo [| 0xD0uy; 0x80uy |]

    [<Test>]
    let ``Given -129 Then return 0xD1FF7F``() =
        -129L |> Packer.packInt64 |> assertEquivalentTo [| 0xD1uy; 0xFFuy; 0x7Fuy |]

    [<Test>]
    let ``Given -32768 Then return 0xD18000``() =
        -32768L |> Packer.packInt64 |> assertEquivalentTo [| 0xD1uy; 0x80uy; 0x00uy |]

    [<Test>]
    let ``Given -32769 Then return 0xD2FFFF7FFF``() =
        -32769L |> Packer.packInt64 |> assertEquivalentTo [| 0xD2uy; 0xFFuy; 0xFFuy; 0x7Fuy; 0xFFuy |]

    [<Test>]
    let ``Given -2147483648 Then return 0xD280000000``() =
        -2147483648L |> Packer.packInt64 |> assertEquivalentTo [| 0xD2uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given -2147483649 Then return 0xD3FFFFFFFF7FFFFFFF``() =
        -2147483649L |> Packer.packInt64 |> assertEquivalentTo [| 0xD3uy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0x7Fuy; 0xFFuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given -9223372036854775808 Then return 0xD38000000000000000``() =
        -9223372036854775808L |> Packer.packInt64 |> assertEquivalentTo [| 0xD3uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module PackFloat32Test =
    [<Test>]
    let ``Given 0.0 Then return 0xCA00000000`` () =
        0.0f |> Packer.packFloat32 |> assertEquivalentTo [| 0xCAuy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 1.00390625 Then reutnr 0xCA3F808000`` () =
        1.00390625f |> Packer.packFloat32 |> assertEquivalentTo [| 0xCAuy; 0x3Fuy; 0x80uy; 0x80uy; 0x00uy |]

    [<Test>]
    let ``Given -1.0000152587890625 Then return 0xCABF800080`` () =
        -1.0000152587890625f |> Packer.packFloat32 |> assertEquivalentTo [| 0xCAuy; 0xBFuy; 0x80uy; 0x00uy; 0x80uy |]

    [<Test>]
    let ``Given +infinity Then return 0xCA7F800000`` () =
        System.Single.PositiveInfinity |> Packer.packFloat32 |> assertEquivalentTo [| 0xCAuy; 0x7Fuy; 0x80uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given -infinity Then return 0xCAFF800000`` () =
        System.Single.NegativeInfinity |> Packer.packFloat32 |> assertEquivalentTo [| 0xCAuy; 0xFFuy; 0x80uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module PackFloatTest =
    [<Test>]
    let ``Given 0.0 Then return 0xCB0000000000000000`` () =
        0.0 |> Packer.packFloat |> assertEquivalentTo [| 0xCBuy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 1.03125 Then return 0xCB3FF0800000000000`` () =
        1.03125 |> Packer.packFloat |> assertEquivalentTo [| 0xCBuy; 0x3Fuy; 0xF0uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given -1.000001430511474609375 Then return 0xCBBFF0000180000000`` () =
        -1.000001430511474609375 |> Packer.packFloat |> assertEquivalentTo [| 0xCBuy; 0xBFuy; 0xF0uy; 0x00uy; 0x01uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given 1.000000000015035084288683719933 Then return 0xCB3FF0000000010880`` () =
        1.000000000015035084288683719933 |> Packer.packFloat |> assertEquivalentTo [| 0xCBuy; 0x3Fuy; 0xF0uy; 0x00uy; 0x00uy; 0x00uy; 0x01uy; 0x08uy; 0x80uy |]

    [<Test>]
    let ``Given +infinity Then return 0xCB7FF0000000000000`` () =
        System.Double.PositiveInfinity |> Packer.packFloat |> assertEquivalentTo [| 0xCBuy; 0x7Fuy; 0xF0uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

    [<Test>]
    let ``Given -infinity Then return 0xCBFFF0000000000000`` () =
        System.Double.NegativeInfinity |> Packer.packFloat |> assertEquivalentTo [| 0xCBuy; 0xFFuy; 0xF0uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module PackNilTest =
    [<Test>]
    let ``When packNil Then return 0xC0`` () =
        Packer.packNil() |> assertEquivalentTo [| 0xC0uy |]

[<TestFixture>]
module PackStringTest =
    [<Test>]
    let ``Given "compact" Then return 0xA7636F6D70616374`` () =
        "compact" |> Packer.packString |> assertEquivalentTo [| 0xA7uy; 0x63uy; 0x6Fuy; 0x6Duy; 0x70uy; 0x61uy; 0x63uy; 0x74uy |]

    [<Test>]
    let ``Given "The quick brown fox jumps over the lazy dog"(the length is 43) Then return byte[] and its format header is 0xD9 and its length is 45`` () =
        let sut = "The quick brown fox jumps over the lazy dog" |> Packer.packString
        sut.Length |> assertEqualTo 45
        sut.[0..1] |> assertEquivalentTo [| 0xD9uy; 0x2Buy |]

    [<Test>]
    let ``Given 258-length string Then return byte[] and its format header is 0xDA and its length is 261`` () =
        let sut = System.String('a', 258) |> Packer.packString
        sut.Length |> assertEqualTo 261
        sut.[0..2] |> assertEquivalentTo [| 0xDAuy; 0x01uy; 0x02uy |]

    [<Test>]
    let ``Given 16909060-length string Then return byte[] and its format header is 0xDB and its length is 16909065`` () =
        let sut = System.String('a', 16909060) |> Packer.packString
        sut.Length |> assertEqualTo 16909065
        sut.[0..4] |> assertEquivalentTo [| 0xDBuy; 0x01uy; 0x02uy; 0x03uy; 0x04uy |]

[<TestFixture>]
module PackBinTest =
    [<Test>]
    let ``Given [| 0 .. 254 |] When packBin Then return byte[] and its format header is 0xC4 and its length is 257`` () =
        let sut = [| 0uy .. 254uy |] |> Packer.packBin
        sut.Length |> assertEqualTo 257
        sut.[0..1] |> assertEquivalentTo [| 0xC4uy; 0xFFuy |]

    [<Test>]
    let ``Given [| 0 .. 255 |] When packBin Then return byte[] and its format header is 0xC5 and its length is 259`` () =
        let sut = [| 0uy .. 255uy |] |> Packer.packBin
        sut.Length |> assertEqualTo 259
        sut.[0..2] |> assertEquivalentTo [| 0xC5uy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given 65535-length bin array When packBin Then return byte[] and its format header is 0xC5 and its length is 65538`` () =
        let sut = Array.create 65535 0uy |> Packer.packBin
        sut.Length |> assertEqualTo 65538
        sut.[0..2] |> assertEquivalentTo [| 0xC5uy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 65536-length bin array When packBin Then return byte[] and its format header is 0xC6 and its length is 65541`` () =
        let sut = Array.create 65536 0uy |> Packer.packBin
        sut.Length |> assertEqualTo 65541
        sut.[0..4] |> assertEquivalentTo [| 0xC6uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module PackArrayTest =
    [<Test>]
    let ``Given UInt8 array of [| 0 1 2 3 |] When pack Then return 0x9400010203`` () =
        let sut = Value.Array [| Value.UInt8(0uy); Value.UInt8(1uy); Value.UInt8(2uy); Value.UInt8(3uy) |] |> Packer.pack
        sut |> assertEquivalentTo [| 0x94uy; 0x00uy; 0x01uy; 0x02uy; 0x03uy |]

    [<Test>]
    let ``Given a 16-length Bool array of [| true .. true |] When pack Then return byte[] and its format header is 0xDC and its length is 19`` () =
        let sut = Array.create 16 (Value.Bool true) |> fun arr -> Value.Array arr |> Packer.pack
        sut.Length |> assertEqualTo 19
        sut.[0..2] |> assertEquivalentTo [| 0xDCuy; 0x00uy; 0x10uy |]
        sut.[3..(sut.Length-1)] |> assertEquivalentTo (Array.create 16 0xC3uy)

    [<Test>]
    let ``Given a 65536-length String array of [| 'a' .. 'a' |] When pack Then return byte[] and its format header is 0xDD and its length is 131077`` () =
        let sut = Array.create 65536 (Value.String "a") |> fun arr -> Value.Array arr |> Packer.pack
        sut.Length |> assertEqualTo 131077
        sut.[0..4] |> assertEquivalentTo [| 0xDDuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]
        //sut.[5..(sut.Length-1)] |> assertEquivalentTo ((Array.create 65536 [| 0xA1uy; 0x61uy |]) |> Array.collect id)

[<TestFixture>]
module PackMapTest =
    [<Test>]
    let ``Given {"compact": true, "schema": 0} When pack Then return 0x82A7636F6D70616374C3A6736368656D6100`` () =
        let sut = Value.Map (Map.ofList [(Value.String("compact"), Value.Bool(true)); (Value.String("schema"), Value.UInt8(0uy))]) |> Packer.pack
        sut |> assertEquivalentTo [| 0x82uy; 0xA7uy; 0x63uy; 0x6Fuy; 0x6Duy; 0x70uy; 0x61uy; 0x63uy; 0x74uy; 0xC3uy; 0xA6uy; 0x73uy; 0x63uy; 0x68uy; 0x65uy; 0x6Duy; 0x61uy; 0x00uy |]

    [<Test>]
    let ``Given 15-length key-value pairs of {1: '1', ..., 15: 'F'} When pack Then return byte[] and its format header is 0x8F and its length is 46`` () =
        let sut = [| for i in 1uy .. 15uy -> (Value.UInt8(i), Value.String(i.ToString("X"))) |] |> Map.ofArray |> Value.Map |> Packer.pack
        sut.Length |> assertEqualTo 46
        sut.[0] |> assertEqualTo 0x8Fuy

    [<Test>]
    let ``Given 16-length key-value pairs of {1: true, ..., 16: false} When pack Then return byte[] and its format header is 0xDE and its length is 35`` () =
        let sut = [| for i in 1uy .. 16uy -> (Value.UInt8(i), Value.Bool(i % 2uy = 0uy)) |] |> Map.ofArray |> Value.Map |> Packer.pack
        sut.Length |> assertEqualTo 35
        sut.[0..2] |> assertEquivalentTo [| 0xDEuy; 0x00uy; 0x10uy |]

    [<Test>]
    let ``Given 65535-length key-value pairs of {1: true, ..., 65535: true} When pack Then return byte[] and its format header is 0xDE and its length is 261761`` () =
        let sut = [| for i in 1us .. 65535us -> (Value.UInt16(i), Value.Bool(i % 2us = 0us)) |] |> Map.ofArray |> Value.Map |> Packer.pack
        sut.Length |> assertEqualTo 261761
        sut.[0..2] |> assertEquivalentTo [| 0xDEuy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given 65536-length key-value pairs of {1: true, ..., 65536: false} When pack Then return byte[] and its format header is 0xDF and its length 261769`` () =
        let sut = [| for i in 1u .. 65536u -> (Value.UInt32(i), Value.Bool(i % 2u = 0u)) |] |> Map.ofArray |> Value.Map |> Packer.pack
        sut.Length |> assertEqualTo 261769
        sut.[0..4] |> assertEquivalentTo [| 0xDFuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module PackExtTest =
    [<Test>]
    let ``Given (1, [| 0 |]) When packExt Then return 0xD40100`` () =
        (1y, [| 0uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD4uy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given (2, [| 0; 1 |]) When packExt Then return 0xD5020001`` () =
        (2y, [| 0uy; 1uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD5uy; 0x02uy; 0x00uy; 0x01uy |]

    [<Test>]
    let ``Given (3, [| 0; 1; 2 |]) When packExt Then return 0xD603000102`` () =
        (3y, [| 0uy; 1uy; 2uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD6uy; 0x03uy; 0x00uy; 0x01uy; 0x02uy |]

    [<Test>]
    let ``Given (4, [| 0; 1; 2; 3 |]) When packExt Then return 0xD60400010203`` () =
        (4y, [| 0uy; 1uy; 2uy; 3uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD6uy; 0x04uy; 0x00uy; 0x01uy; 0x02uy; 0x03uy |]

    [<Test>]
    let ``Given (5, [| 0 .. 4 |]) When packExt Then return 0xD7050001020304`` () =
        (5y, [| 0uy .. 4uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD7uy; 0x05uy; 0x00uy; 0x01uy; 0x02uy; 0x03uy; 0x04uy |]

    [<Test>]
    let ``Given (6, [| 0 .. 7 |]) When packExt Then return 0xD70600010120304050607`` () =
        (6y, [| 0uy .. 7uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD7uy; 0x06uy; 0x00uy; 0x01uy; 0x02uy; 0x03uy; 0x04uy; 0x05uy; 0x06uy; 0x07uy |]

    [<Test>]
    let ``Given (7, [| 0 .. 8 |]) When packExt Then return 0xD807000102030405060708`` () =
        (7y, [| 0uy .. 8uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD8uy; 0x07uy; 0x00uy; 0x01uy; 0x02uy; 0x03uy
                                                                           0x04uy; 0x05uy; 0x06uy; 0x07uy; 0x08uy |]

    [<Test>]
    let ``Given (8, [| 0 .. 15 |]) When packExt Then return 0xD808000102030405060708090A0B0C0D0E0F`` () =
        (8y, [| 0uy .. 15uy |]) ||> Packer.packExt |> assertEquivalentTo [| 0xD8uy; 0x08uy; 0x00uy; 0x01uy; 0x02uy; 0x03uy; 0x04uy; 0x05uy; 0x06uy
                                                                            0x07uy; 0x08uy; 0x09uy; 0x0Auy; 0x0Buy; 0x0Cuy; 0x0Duy; 0x0Euy; 0x0Fuy |] 

    [<Test>]
    let ``Given (9, [| 0 .. 16 |]) When packExt Then return byte[] and its format header is 0xC7 and its length is 20`` () =
        let sut = (9y, [| 0uy .. 16uy |]) ||> Packer.packExt
        sut.Length |> assertEqualTo 20
        sut.[0..1] |> assertEquivalentTo [| 0xC7uy; 0x11uy |]

    [<Test>]
    let ``Given (10, [| 0 .. 254 |]) When packExt Then return byte[] and its format header is 0xC7 and its length is 258`` () =
        let sut = (10y, [| 0uy .. 254uy |]) ||> Packer.packExt
        sut.Length |> assertEqualTo 258
        sut.[0..1] |> assertEquivalentTo [| 0xC7uy; 0xFFuy |]

    [<Test>]
    let ``Given (11, [| 0 .. 255 |]) When packExt Then return byte[] and its format header is 0xC8 and its length is 260`` () =
        let sut = (11y, [| 0uy .. 255uy |]) ||> Packer.packExt
        sut.Length |> assertEqualTo 260
        sut.[0..2] |> assertEquivalentTo [| 0xC8uy; 0x01uy; 0x00uy |]

    [<Test>]
    let ``Given (12, 65535-length array) When packExt Then return byte[] and its format header is 0xC8 and its length is 65539`` () =
        let sut = (12y, (Array.create 65535 0uy)) ||> Packer.packExt
        sut.Length |> assertEqualTo 65539
        sut.[0..2] |> assertEquivalentTo [| 0xC8uy; 0xFFuy; 0xFFuy |]

    [<Test>]
    let ``Given (13, 65536-length array) When packExt Then return byte[] and its format header is 0xC9 and its length is 65542`` () =
        let sut = (13y, (Array.create 65536 0uy)) ||> Packer.packExt
        sut.Length |> assertEqualTo 65542
        sut.[0..4] |> assertEquivalentTo [| 0xC9uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |]

[<TestFixture>]
module UnpackTest =
    [<Test>]
    let ``Given 0x00 When unpack Then return seq [Value.UInt8 0]`` () =
        Unpacker.unpack [| 0x00uy |] |> assertEquivalentTo (seq [ Value.UInt8 0uy ])

    [<Test>]
    let ``Given 0x7F When unpack Then return seq [Value.UInt8 127]`` () =
        Unpacker.unpack [| 0x7Fuy |] |> assertEquivalentTo (seq [ Value.UInt8 127uy ])

    [<Test>]
    let ``Given 0x8F and byte * bool array of [(0, false); (1, true) .. (14, false)] When unpack Then return seq [Value.Map { Value.UInt8 0: Value.Bool false .. Value.UInt8 14: Value.Bool false }`` () =
        let bs = Array.init 15 (fun i -> if i % 2 = 0 then [| byte(i); 0xC2uy |] else [| byte(i); 0xC3uy |]) |> Array.concat
        let expected = List.init 15 (fun i -> ((i |> byte |> Value.UInt8), if i % 2 = 0 then Value.Bool false else Value.Bool true)) |> Map.ofList
        Array.append [| 0x8Fuy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Map(expected)])

    [<Test>]
    let ``Given 0x9F and byte array of [0 .. 14] When unpack Then return seq [Value.Array [|Value.UInt8 0 ... Value.UInt8 14|]]`` () =
        let bs = Array.init 15 (fun i -> byte(i))
        let expected = Array.init 15 (fun i -> i |> byte |> Value.UInt8)
        Array.append [| 0x9Fuy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Array(expected)])

    [<Test>]
    let ``Given 0xAB4D6573736167655061636B When unpack Then return seq [Value.String "MessagePack"]`` () =
        Unpacker.unpack [| 0xABuy; 0x4Duy; 0x65uy; 0x73uy; 0x73uy; 0x61uy; 0x67uy; 0x65uy; 0x50uy; 0x61uy; 0x63uy; 0x6Buy |]
        |> assertEquivalentTo (seq [Value.String "MessagePack"])

    [<Test>]
    let ``Given 0xC0 When unpack Then return seq [Value.Nil]`` () =
        Unpacker.unpack [| 0xC0uy |] |> assertEquivalentTo (seq [Value.Nil])

    [<Test>]
    let ``Given 0xC2 When unpack Then return seq [Value.Bool false]`` () =
        Unpacker.unpack [| 0xC2uy |] |> assertEquivalentTo (seq [Value.Bool false])

    [<Test>]
    let ``Given 0xC3 When unpack Then return seq [Value.Bool true]`` () =
        Unpacker.unpack [| 0xC3uy |] |> assertEquivalentTo (seq [Value.Bool true])

    [<Test>]
    let ``Given 0xC4FF and 255-length of 0xFF array When unpack Then return seq [Value.Bin (255-length of 0xFF)]`` () =
        let bs = Array.init 255 (fun _ -> 0xFFuy)
        Array.append [| 0xC4uy; 0xFFuy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Bin bs])

    [<Test>]
    let ``Given 0xC50100 and 256-length of 0x20 array When unpack Then return seq [Value.Bin (256-length of 0x20)]`` () =
        let bs = Array.init 256 (fun _ -> 0x20uy)
        Array.append [| 0xC5uy; 0x01uy; 0x00uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Bin bs])

    [<Test>]
    let ``Given 0xC5FFFF and 65535-length of 0x30 array When unpack Then return seq [Value.Bin (65535-length of 0x30)]`` () =
        let bs = Array.init 65535 (fun _ -> 0x30uy)
        Array.append [| 0xC5uy; 0xFFuy; 0xFFuy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Bin bs])

    [<Test>]
    let ``Given 0xC600010000 and 65536-length of 0x41 array When unpack Then return seq [Value.Bin (65536-length of 0x41)]`` () =
        let bs = Array.init 65536 (fun _ -> 0x41uy)
        Array.append [| 0xC6uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Bin bs])

    [<Test>]
    let ``Given 0xC7FF01 and 255-length of 0xFF array When unpack Then return seq [Value.Ext (1, 255-length of 0xFF)]`` () =
        let bs = Array.init 255 (fun _ -> 0xFFuy)
        Array.append [| 0xC7uy; 0xFFuy; 0x01uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext(1y, bs)])

    [<Test>]
    let ``Given 0xC8010002 and 256-length of 0x20 array When unpack Then return seq [Value.Ext (2, 256-length of 0x20)]`` () =
        let bs = Array.init 256 (fun _ -> 0x20uy)
        Array.append [| 0xC8uy; 0x01uy; 0x00uy; 0x02uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext(2y, bs)])

    [<Test>]
    let ``Given 0xC8FFFF03 and 65535-length of 0x30 array When unpack Then return seq [Value.Ext (3, 65535-length 0f 0x30)]`` () =
        let bs = Array.init 65535 (fun _ -> 0x30uy)
        Array.append [| 0xC8uy; 0xFFuy; 0xFFuy; 0x03uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext(3y, bs)])

    [<Test>]
    let ``Given 0xC90001000004 and 65536-length of 0x41 array When unpack Then return seq [Value.Ext (4, 65536-length of 0x41)]`` () =
        let bs = Array.init 65536 (fun _ -> 0x41uy)
        Array.append [| 0xC9uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy; 0x04uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext(4y, bs)])

    [<Test>]
    let ``Given 0xCA3E200000 When unpack Then return seq [Value.Float32 0.15625]`` () =
        Unpacker.unpack [| 0XCAuy; 0x3Euy; 0x20uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Float32 0.15625f])

    [<Test>]
    let ``Given 0xCA7F800000 When unpack Then return seq [Value.Float32 +infinity]`` () =
        Unpacker.unpack [| 0xCAuy; 0x7Fuy; 0x80uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Float32 System.Single.PositiveInfinity])

    [<Test>]
    let ``Given 0xCBBFF0000180000000 When unpack Then return seq [Value.Float64 -1.000001430511474609375]`` () =
        Unpacker.unpack [| 0xCBuy; 0xBFuy; 0xF0uy; 0x00uy; 0x01uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Float64 (-1.000001430511474609375)])

    [<Test>]
    let ``Given 0xCBFFF0000000000000 When unpack Then return seq [Value.Float64 -infinity]`` () =
        Unpacker.unpack [| 0xCBuy; 0xFFuy; 0xF0uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Float64 System.Double.NegativeInfinity])

    [<Test>]
    let ``Given 0xCC80 When unpack Then return seq [Value.UInt8 128]`` () =
        Unpacker.unpack [| 0xCCuy; 0x80uy |] |> assertEquivalentTo (seq [ Value.UInt8 128uy ])

    [<Test>]
    let ``Given 0xCCFF When unpack Then return seq [Value.UInt8 255]`` () =
        Unpacker.unpack [| 0xCCuy; 0xFFuy |] |> assertEquivalentTo (seq [ Value.UInt8 255uy ])

    [<Test>]
    let ``Given 0xCD0100 When unpack Then return seq [Value.UInt16 256]`` () =
        Unpacker.unpack [| 0xCDuy; 0x01uy; 0x00uy |] |> assertEquivalentTo (seq [ Value.UInt16 256us ])

    [<Test>]
    let ``Given 0xCDFFFF When unpack Then return seq [Value.UInt16 65535]`` () =
        Unpacker.unpack [| 0xCDuy; 0xFFuy; 0xFFuy |] |> assertEquivalentTo (seq [ Value.UInt16 65535us ])

    [<Test>]
    let ``Given 0xCE00010000 When unpack Then return seq [Value.UInt32 65536]`` () =
        Unpacker.unpack [| 0xCEuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.UInt32 65536u ])

    [<Test>]
    let ``Given 0xCEFFFFFFFF When unpack Then return seq [Value.UInt32 4294967295]`` () =
        Unpacker.unpack [| 0xCEuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |] |> assertEquivalentTo (seq [Value.UInt32 4294967295u ])

    [<Test>]
    let ``Given 0xCF0000000100000000 When unpack Then return seq [Value.UInt64 4294967296]`` () =
        Unpacker.unpack [| 0xCFuy; 0x00uy; 0x00uy; 0x00uy; 0x01uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.UInt64 4294967296UL ])

    [<Test>]
    let ``Given 0xCFFFFFFFFFFFFFFFFF When unpack Then return seq [Value.UInt64 18446744073709551615]`` () =
        Unpacker.unpack [| 0xCFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |] |> assertEquivalentTo (seq [Value.UInt64 18446744073709551615UL ])

    [<Test>]
    let ``Given 0xD0DF When unpack Then return seq [Value.Int8  (-33)]`` () =
        Unpacker.unpack [| 0xD0uy; 0xDFuy |] |> assertEquivalentTo (seq [Value.Int8 (-33y)])

    [<Test>]
    let ``Given 0xD080 When unpack Then return seq [Value.Int8 (-128)]`` () =
        Unpacker.unpack [| 0xD0uy; 0x80uy |] |> assertEquivalentTo (seq [Value.Int8 (-128y)])

    [<Test>]
    let ``Given 0xD1FF7F When unpack Then return seq [Value.Int16 (-129)]`` () =
        Unpacker.unpack [| 0xD1uy; 0xFFuy; 0x7Fuy |] |> assertEquivalentTo (seq [Value.Int16 (-129s)])

    [<Test>]
    let ``Given 0xD18000 When unpack Then return seq [Value.Int16 (-32768)]`` () =
        Unpacker.unpack [| 0xD1uy; 0x80uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Int16 (-32768s)])

    [<Test>]
    let ``Given 0xD2FFFF7FFF When unpack Then return seq [Value.Int32 (-32769)]`` () =
        Unpacker.unpack [| 0xD2uy; 0xFFuy; 0xFFuy; 0x7Fuy; 0xFFuy |] |> assertEquivalentTo (seq [Value.Int32 (-32769)])

    [<Test>]
    let ``Given 0xD280000000 When unpack Then return seq [Value.Int32 (-2147483648)]`` () =
        Unpacker.unpack [| 0xD2uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Int32 (-2147483648)])

    [<Test>]
    let ``Given 0xD3FFFFFFFF7FFFFFFF When unpack Then return seq [Value.Int64 (-2147483649)]`` () =
        Unpacker.unpack [| 0xD3uy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy; 0x7Fuy; 0xFFuy; 0xFFuy; 0xFFuy |] |> assertEquivalentTo (seq [Value.Int64 (-2147483649L)])

    [<Test>]
    let ``Given 0xD38000000000000000 When unpack Then return seq [Value.Int64 (-9223372036854775808)]`` () =
        Unpacker.unpack [| 0xD3uy; 0x80uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy; 0x00uy |] |> assertEquivalentTo (seq [Value.Int64 (-9223372036854775808L)])

    [<Test>]
    let ``Given 0xD405FF When unpack Then return seq [Value.Ext (5, [| 0xFF |])]`` () =
        [| 0xD4uy; 0x05uy; 0xFFuy |] |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext (5y, [| 0xFFuy |])])

    [<Test>]
    let ``Given 0xD5062030 When unpack Then return seq [Value.Ext (6, [| 0x20; 0x30 |])]`` () =
        [| 0xD5uy; 0x06uy; 0x20uy; 0x30uy |] |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext (6y, [| 0x20uy; 0x30uy |])])

    [<Test>]
    let ``Given 0xD607FF203041 When unpack Then return seq [Value.Ext (7, [| 0xFF; 0x20; 0x30; 0x41 |])]`` () =
        [| 0xD6uy; 0x07uy; 0xFFuy; 0x20uy; 0x30uy; 0x41uy |] |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext (7y, [| 0xFFuy; 0x20uy; 0x30uy; 0x41uy |])])

    [<Test>]
    let ``Given 0xD708203041FF203041FF When unpack Then return seq [Value.Ext (8, [| 0x20; 0x30; 0x41; 0xFF; 0x20; 0x30; 0x41; 0xFF |])]`` () =
        [| 0xD7uy; 0x08uy; 0x20uy; 0x30uy; 0x41uy; 0xFFuy; 0x20uy; 0x30uy; 0x41uy; 0xFFuy |] |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Ext (8y, [| 0x20uy; 0x30uy; 0x41uy; 0xFFuy; 0x20uy; 0x30uy; 0x41uy; 0xFFuy |])])

    [<Test>]
    let ``Given 0xD809202020203041304130413041FFFFFFFF When unpack Then return seq [Value.Ext (9, [| 0x20; 0x20; 0x20; 0x20; 0x30; 0x41; 0x30; 0x41; 0x30; 0x41; 0x30; 0x41; 0xFF; 0xFF; 0xFF; 0xFF |])]`` () =
        let bs = [| 0xD8uy; 0x09uy; 0x20uy; 0x20uy; 0x20uy; 0x20uy; 0x30uy; 0x41uy; 0x30uy; 0x41uy; 0x30uy; 0x41uy; 0x30uy; 0x41uy; 0xFFuy; 0xFFuy; 0xFFuy; 0xFFuy |]
        Unpacker.unpack bs |> assertEquivalentTo (seq [Value.Ext (9y, bs.[2..])])

    [<Test>]
    let ``Given 0xD920 and 32-length of 0x41 array When unpack Then return seq [Value.String (32-length of "A")]`` () =
        Array.append [| 0xD9uy; 0x20uy |] (Array.init 32 (fun _ -> 0x41uy)) |> Unpacker.unpack |> assertEquivalentTo (seq [Value.String (System.String('A', 32))])
    
    [<Test>]
    let ``Given 0xD9FF and 255-length of 0x61 array When unpack Then return seq [Value.String (255-length of "a")]`` () =
        Array.append [| 0xD9uy; 0xFFuy |] (Array.init 255 (fun _ -> 0x61uy)) |> Unpacker.unpack |> assertEquivalentTo (seq [Value.String (System.String('a', 255))])

    [<Test>]
    let ``Given 0xDA0100 and 256-length of 0x30 array When unpack Then return seq [Value.String (256-length of "0")]`` () =
        Array.append [| 0xDAuy; 0x01uy; 0x00uy |] (Array.init 256 (fun _ -> 0x30uy)) |> Unpacker.unpack |> assertEquivalentTo (seq [Value.String (System.String('0', 256))])

    [<Test>]
    let ``Given 0xDAFFFF and 65535-length of 0x39 array When unpack Then return seq [Value.String (65535-length of "9")]`` () =
        Array.append [| 0xDAuy; 0xFFuy; 0xFFuy |] (Array.init 65535 (fun _ -> 0x39uy)) |> Unpacker.unpack |> assertEquivalentTo (seq [Value.String (System.String('9', 65535))])

    [<Test>]
    let ``Given 0xDB00010000 and 65536-length of 0x20 array When unpack Then return seq [Value.String (65536-length of " ")]`` () =
        Array.append [| 0xDBuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |] (Array.init 65536 (fun _ -> 0x20uy)) |> Unpacker.unpack |> assertEquivalentTo (seq [Value.String (System.String(' ', 65536))])

    [<Test>]
    let ``Given 0xDC0010 and 16-length of 0xC0 array When unpack Then return seq [Value.Array (16-length of Value.Nil)]`` () =
        let bs = Array.init 16 (fun _ -> 0xC0uy)
        let expected = Array.init 16 (fun _ -> Value.Nil)
        Array.append [| 0xDCuy; 0x00uy; 0x10uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Array(expected)])

    [<Test; Category("TooSlowTest")>]
    let ``Given 0xDCFFFF and 65535-length of 0xC2 array When unpack Then return seq [Value.Array (65535-length of Value.Bool false)]`` () =
        let bs = Array.init 65535 (fun _ -> 0xC2uy)
        let expected = Array.init 65535 (fun _ -> Value.Bool false)
        Array.append [| 0xDCuy; 0xFFuy; 0xFFuy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Array(expected)])

    [<Test; Category("TooSlowTest")>]
    let ``Given 0xDD00010000 and 65536-length of 0xC3 array When unpack Then return seq [Value.Array (65536-length of Value.Bool true)]`` () =
        let bs = Array.init 65536 (fun _ -> 0xC3uy)
        let expected = Array.init 65536 (fun _ -> Value.Bool true)
        Array.append [| 0xDDuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Array(expected)])

    [<Test>]
    let ``Given 0xDE0010 and 16-length of key value collections When unpack Then return seq [Value.Map (16-length of (int format family, bool format family))]`` () =
        let bs = Array.init 16 (fun i -> if i % 2 = 0 then [| byte(i); 0xC2uy |] else [| byte(i); 0xC3uy |]) |> Array.concat
        let expected = List.init 16 (fun i -> (i |> byte |> Value.UInt8), if i % 2 = 0 then Value.Bool false else Value.Bool true) |> Map.ofList
        Array.append [| 0xDEuy; 0x00uy; 0x10uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Map(expected)])

    [<Test; Category("TooSlowTest")>]
    let ``Given 0xDEFFFF and 65535-length of key value collections When unpack Then return seq [Value.Map (65535-length of (int format family, bool format family))]`` () =
        let bs = Array.init 65535 (fun i -> Array.append (Packer.packInt i) [| (if i % 2 = 0 then 0xC2uy else 0xC3uy) |]) |> Array.concat
        let expected =
            List.init 65535
                (fun i ->
                    if i <= 255 then
                        i |> byte |> Value.UInt8
                    else
                        i |> uint16 |> Value.UInt16
                    , if i % 2 = 0 then Value.Bool false else Value.Bool true)
            |> Map.ofList
        Array.append [| 0xDEuy; 0xFFuy; 0xFFuy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Map(expected)])

    [<Test; Category("TooSlowTest")>]
    let ``Given 0xDF00010000 and 65536-length of key value collections When unpack Then return seq [Value.Map (65536-length of (int format family, bool format family))]`` () =
        let bs = Array.init 65536 (fun i -> Array.append (Packer.packInt i) [| 0xC3uy |]) |> Array.concat
        let expected =
            List.init 65536
                (fun i ->
                    if i <= 255 then
                        i |> byte |> Value.UInt8
                    elif i<= 65535 then
                        i |> uint16 |> Value.UInt16
                    else
                        i |> uint32 |> Value.UInt32
                    , Value.Bool true)
            |> Map.ofList
        Array.append [| 0xDFuy; 0x00uy; 0x01uy; 0x00uy; 0x00uy |] bs |> Unpacker.unpack |> assertEquivalentTo (seq [Value.Map(expected)])

    [<Test>]
    let ``Given 0xFF When unpack Then return seq [Value.Int8 (-1)]`` () =
        Unpacker.unpack [| 0xFFuy |] |> assertEquivalentTo (seq [Value.Int8 (-1y)])

    [<Test>]
    let ``Given 0xE0 When unpack Then return seq [Value.Int8 (-32)]`` () =
        Unpacker.unpack [| 0xE0uy |] |> assertEquivalentTo (seq [Value.Int8 (-32y)])